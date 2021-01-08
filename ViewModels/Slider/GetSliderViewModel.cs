using System;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetSliderViewModel
    {
        public GetSliderViewModel(Slider slider)
        {
            FirstSlide = slider.FirstSlide;
            SecondSlide = slider.SecondSlide;
            ThirdSlide = slider.ThirdSlide;
            FourthSlide = slider.FourthSlide;
            FifthSlide = slider.FifthSlide;
        }

        public string FirstSlide { get; set; }
        public string SecondSlide { get; set; }
        public string ThirdSlide { get; set; }
        public string FourthSlide { get; set; }
        public string FifthSlide { get; set; }
    }
}
