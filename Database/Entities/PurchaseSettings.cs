using System;
namespace shop_backend.Database.Entities
{
    public class PurchaseSettings
    {
        public int Id { get; set; }
        public bool IsShippingAvaible { get; set; }
        public bool IsPersonalPickupAvaible { get; set; }
        public bool IsDotpayAvaible { get; set; }
        public bool IsCashAvaible { get; set; }
        public bool IsTransferAvaible { get; set; }
        public string TransferNumber { get; set; }
    }
}
