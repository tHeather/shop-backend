using System;
using System.Collections.Generic;
using System.Text.Json;
using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class GetOrderViewModel
    {
        public GetOrderViewModel(Order order)
        {
            Id = order.Id;
            DeliveryMethod = order.DeliveryMethod;
            PaymentMethod = order.PaymentMethod;
            Firstname = order.Firstname;
            Surname = order.Surname;
            EmailAddress = order.EmailAddress;
            PhoneNumber = order.PhoneNumber;
            Products = JsonSerializer.Deserialize<List<OrderProduct>>(order.Products);
            Price = order.Price;
            OrderStatus = order.OrderStatus;
            DateTime = order.DateTime;
            City = order.City;
            PostalCode = order.PostalCode;
            Street = order.Street;
            StreetNumber = order.StreetNumber;
            DotPayOperationNumber = order.DotPayOperationNumber;
            PersonalPickupBranch = order.PersonalPickupBranch;
        }

        public int Id { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderProduct> Products { get; set; }
        public int Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime DateTime { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string DotPayOperationNumber { get; set; }
        public PersonalPickupBranch PersonalPickupBranch { get; set; }
    }
}
