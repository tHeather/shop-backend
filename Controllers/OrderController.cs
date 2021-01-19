using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels;
using StudyOnlineServer.ViewModels;

namespace shop_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IDotPayService dotPayService;
        private readonly IPurchaseSettingsRepository purchaseSettingsRepository;
        private readonly ISendgridService sendgridService;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository, IDotPayService dotPayService,
                              IPurchaseSettingsRepository purchaseSettingsRepository, ISendgridService sendgridService)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.dotPayService = dotPayService;
            this.purchaseSettingsRepository = purchaseSettingsRepository;
            this.sendgridService = sendgridService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<PagedResult<GetOrderViewModel>>> GetAllOrders([Required]int pageNumber, string search, DeliveryMethod? deliveryMethod, PaymentMethod? paymentMethod, bool? sortByDateDescending)
        {
            var orders = await orderRepository.GetAllOrdersAsync(pageNumber, search, deliveryMethod, paymentMethod, sortByDateDescending);
            return Ok(new PagedResult<GetOrderViewModel> {
                CurrentPage = orders.CurrentPage,
                HasNext = orders.HasNext,
                TotalPages = orders.TotalPages,
                Result = orders.Select(o => new GetOrderViewModel(o))
            });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<OrderCreatedViewModel>> CreateOrder(CreateOrderViewModel createOrderViewModel)
        {
            var purchaseSettings = await purchaseSettingsRepository.GetAsync();
            switch (createOrderViewModel.PaymentMethod)
            {
                case PaymentMethod.Dotpay:
                    if (purchaseSettings.IsDotpayAvaible)
                        break;

                    return BadRequest(new ValidationErrors("Dotpay is not enabled."));

                case PaymentMethod.Cash:
                    if (purchaseSettings.IsCashAvaible)
                        break;

                    return BadRequest(new ValidationErrors("Cash is not enabled"));

                case PaymentMethod.BankTransfer:
                    if (purchaseSettings.IsTransferAvaible)
                        break;

                    return BadRequest(new ValidationErrors("Bank transfer is not enabled"));
            }

            if (createOrderViewModel.DeliveryMethod == DeliveryMethod.Shipping)
            {
                if (!purchaseSettings.IsShippingAvaible)
                    return BadRequest(new ValidationErrors("Shipping is not enabled"));

                if (createOrderViewModel.DeliveryAddress == null)
                    return BadRequest(new ValidationErrors("Address is required with delivery method shipping"));
            }

            if(createOrderViewModel.DeliveryMethod == DeliveryMethod.PersonalPickup)
            {
                if (!purchaseSettings.IsPersonalPickupAvaible)
                    return BadRequest(new ValidationErrors("Perosonal pickup is not enabled."));

                if (!createOrderViewModel.PersonalPickupBranchId.HasValue)
                    return BadRequest(new ValidationErrors("Branch id is required with delivery method personal pickup"));
            }

            var products = await productRepository.GetByIdsAsync(createOrderViewModel.Products.Select(p => p.ProductId));
            if (products.Count != createOrderViewModel.Products.Count)
                return BadRequest(new ValidationErrors("Not all products exists"));

            var errorsLit = new List<string>();
            createOrderViewModel.Products.ForEach(p =>
            {
                var productFromDb = products.SingleOrDefault(x => x.Id == p.ProductId);
                if (productFromDb.Quantity < p.ProductQuantity)
                    errorsLit.Add($"Not enough of {productFromDb.Name}, there is only {productFromDb.Quantity} left.");
            });

            if (errorsLit.Any())
                return BadRequest(new ValidationErrors(errorsLit));

            var orderProducts = new List<OrderProduct>();
            var fullPrice = 0;
            foreach(var product in products)
            {
                var quantity = createOrderViewModel.Products.SingleOrDefault(x => x.ProductId == product.Id).ProductQuantity;
                orderProducts.Add(new OrderProduct
                {
                    Name = product.Name,
                    Manufacturer = product.Manufacturer,
                    Quantity = quantity,
                    Price = product.Price,
                    FirstImage = product.FirstImage
                });

                if (product.IsOnDiscount)
                {
                    fullPrice += product.DiscountPrice.Value * quantity;
                }
                else
                {
                    fullPrice += product.Price * quantity;
                }
            }

            var order = new Order
            {
                DeliveryMethod = createOrderViewModel.DeliveryMethod,
                PaymentMethod = createOrderViewModel.PaymentMethod,
                EmailAddress = createOrderViewModel.EmailAddress,
                Firstname = createOrderViewModel.Firstname,
                Surname = createOrderViewModel.Surname,
                PhoneNumber = createOrderViewModel.PhoneNumber,
                PersonalPickupBranchId = createOrderViewModel.PersonalPickupBranchId,
                City = createOrderViewModel.DeliveryAddress?.City,
                PostalCode = createOrderViewModel.DeliveryAddress?.PostalCode,
                Street = createOrderViewModel.DeliveryAddress?.Street,
                StreetNumber = createOrderViewModel.DeliveryAddress?.StreetNumber,
                Products = JsonSerializer.Serialize(orderProducts),
                Price = fullPrice,
                OrderStatus = OrderStatus.Created,
                DateTime = DateTime.Now
            };

            await orderRepository.CreateAsync(order);

            var response = new OrderCreatedViewModel
            {
                PaymentMethod = order.PaymentMethod,
            };

            if(order.PaymentMethod == PaymentMethod.Dotpay)
            {
                response.Message = $"Order successful transaction id: {order.Id}.";
                var callbackUrl = $"https://{HttpContext.Request.Host}/api/Order/dotpay-callback";
                response.DotPayRedirectLink = dotPayService.CreatePaymentTransactionUri(order.Id, order.Price, order.EmailAddress, callbackUrl);
            }
            else if(order.PaymentMethod == PaymentMethod.BankTransfer)
            {
                response.Message = $"Order successful transaction id: {order.Id}, please send cash to: {purchaseSettings.TransferNumber}.";
            }
            else
            {
                response.Message = $"Order successful transaction id: {order.Id}, you will be notified, with futher actions.";
            }

            _ = sendgridService.SendOrderConfirmationEmail(order.EmailAddress, response.Message);
            return Ok(response);
        }

        [HttpPut("status/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdateOrderStatus(int id, UpdateOrderStatusViewModel updateOrderStatusViewModel)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            order.OrderStatus = updateOrderStatusViewModel.OrderStatus;
            await orderRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("dotpay-callback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DotPayCallback([FromForm] DotPayCallback dotPayCallback)
        {
            //var dotpayIp = "195.150.9.37";
            //var ip = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            //if (dotpayIp != ip)
            //{
            //    Log.ForContext("CallbackIP", ip).Error("Wrong dotpay callback ip address." + ip); TODO Turn on on production
            //    return Ok("OK");
            //}

            if (dotPayCallback.operation_type != "payment")
            {
                //Log.ForContext("OperationType", dotPayCallback.operation_type).Error("Bad transaction type.");
                return Ok("OK");
            }

            if (dotPayCallback.operation_status != "completed" && dotPayCallback.operation_status != "rejected")
            {
                //Log.ForContext("OperationStatus", dotPayCallback.operation_status).Error("Bad transaction status.");
                return Ok("OK");
            }

            if (dotPayCallback.operation_amount != dotPayCallback.operation_original_amount)
            {
                //Log.ForContext("OperationAmount", dotPayCallback.operation_amount).ForContext("OriginalAmount", dotPayCallback.operation_original_amount).Error("Bad transaction amount."); ;
                return Ok("OK");
            }

            if (dotPayCallback.operation_currency != dotPayCallback.operation_original_currency)
            {
                //Log.ForContext("OperationCurrency", dotPayCallback.operation_currency).ForContext("OriginalCurrency", dotPayCallback.operation_original_currency).Error("Bad transaction currency.");
                return Ok("OK");
            }

            var paramsString = dotPayCallback.operation_number + dotPayCallback.operation_type + dotPayCallback.operation_status
                + dotPayCallback.operation_amount + dotPayCallback.operation_currency + dotPayCallback.operation_original_amount +
                dotPayCallback.operation_original_currency + dotPayCallback.operation_datetime + dotPayCallback.control + dotPayCallback.description +
                dotPayCallback.email + dotPayCallback.p_info + dotPayCallback.p_email + dotPayCallback.channel;

            var calcSignature = dotPayService.GenerateChk(paramsString, true);
            if (calcSignature != dotPayCallback.signature)
            {
                //Log.Error("Signature dosen't match.");
                return Ok("OK");
            }

            var order = await orderRepository.GetByIdAsync(dotPayCallback.control);
            if (order == null)
            {
                //Log.ForContext("TransactionId", dotPayCallback.control).Error("Transaction not found.");
                return Ok("OK");
            }

            var dotpayStatus = Enum.Parse<DotPayOperationStatus>(dotPayCallback.operation_status, true);
            if(dotpayStatus == DotPayOperationStatus.Completed)
            {
                order.OrderStatus = OrderStatus.Paid;
            }
            order.DotPayOperationNumber = dotPayCallback.operation_number;
            await orderRepository.SaveChangesAsync();
            _ = sendgridService.SendOrderConfirmationEmail(order.EmailAddress, "Order paid");
            //Log.ForContext("TransactionId", transaction.Id).ForContext("DotpayOperationNumber", transaction.DotPayOperationNumber).Information("Account top up verified successfully.");
            return Ok("OK");
        }
    }
}
