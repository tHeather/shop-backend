using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class OrderCreatedViewModel
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string Message { get; set; }
        public string DotPayRedirectLink { get; set; }
    }
}
