using System;
using Microsoft.AspNetCore.Http;

namespace shop_backend.ViewModels
{
    public class UpdateSliderViewModel
    {
        public IFormFile FirstSlide { get; set; }
        public IFormFile SecondSlide { get; set; }
        public IFormFile ThirdSlide { get; set; }
        public IFormFile FourthSlide { get; set; }
        public IFormFile FifthSlide { get; set; }
    }
}
