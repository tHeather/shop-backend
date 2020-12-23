using Microsoft.AspNetCore.Http;
using ShopBackend.BusinessLogic.Attributes;

namespace ShopBackend.BusinessLogic.ViewModels
{
    public class UpdateThemeViewModel
    {
        [ColorValidation]
        public string LeadingColor { get; set; }

        [ColorValidation]
        public string SecondaryColor { get; set; }

        [ColorValidation]
        public string TertiaryColor { get; set; }

        public IFormFile Logo { get; set; }
    }
}
