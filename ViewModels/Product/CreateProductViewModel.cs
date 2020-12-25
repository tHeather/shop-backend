using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using shop_backend.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace shop_backend.ViewModels
{
    public class CreateProductViewModel 
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }

        [Required]
        public bool IsOnDiscount { get; set; }

        [Range(1, 999999)]
        [IsProductOnDiscountValidation("IsOnDiscount")]
        public int? DiscountPrice { get; set; }

        public IFormFile FirstImage { get; set; }

        public IFormFile SecondImage { get; set; }

        public IFormFile ThirdImage { get; set; }

        public Product MapToEntity() => new Product
        {
            Name = Name,
            Type = Type,
            Description = Description,
            DiscountPrice = DiscountPrice,
            IsOnDiscount = IsOnDiscount,
            Manufacturer = Manufacturer,
            Price = Price,
            Quantity = Quantity
        };
    }
}