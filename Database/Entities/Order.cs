using System;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.Database.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Products { get; set; }
        public int Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime DateTime { get; set; }

        public int? PersonalPickupBranchId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string DotPayOperationNumber { get; set; }

        public PersonalPickupBranch PersonalPickupBranch { get; set; }
    }
}
