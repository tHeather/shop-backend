using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetProductViewModel 
    {
      public GetProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Type = product.Type;
            Manufacturer = product.Manufacturer;
            Description = product.Description;
            Quantity = product.Quantity;
            Price = product.Price;
            IsOnDiscount = product.IsOnDiscount;
            DiscountPrice = product.DiscountPrice;
            FirstImage = product.FirstImage;
            SecondImage = product.SecondImage;
            ThirdImage = product.ThirdImage;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool IsOnDiscount { get; set; }
        public int? DiscountPrice { get; set; }
        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string ThirdImage { get; set; }
    }
}