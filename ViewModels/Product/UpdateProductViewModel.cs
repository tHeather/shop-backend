﻿using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using shop_backend.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.ViewModels
{
    public class UpdateProductViewModel
    {

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }

        [Required]
        public bool IsOnDiscount { get; set; }

        [Range(1, 1000000)]
        [IsProductOnDiscountValidation("IsOnDiscount")]
        public int? DiscountPrice { get; set; }

        public IFormFile FirstImage { get; set; }
        public IFormFile SecondImage { get; set; }
        public IFormFile ThirdImage { get; set; }
    }
}
