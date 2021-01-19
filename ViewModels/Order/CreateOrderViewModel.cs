using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required]
        public DeliveryMethod DeliveryMethod { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public List<BuyProduct> Products { get; set; }

        public int? PersonalPickupBranchId { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
    }

    public class BuyProduct
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }

    public class DeliveryAddress
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
