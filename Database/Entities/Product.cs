namespace shop_backend.Database.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string  Type  { get; set; }
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
