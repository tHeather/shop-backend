using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class UpdateShopSettingsViewModel
    {
        [Required]
        [ColorValidation]
        public string LeadingColor { get; set; }

        [Required]
        [ColorValidation]
        public string SecondaryColor { get; set; }

        [Required]
        [ColorValidation]
        public string NavbarColor { get; set; }

        [Required]
        [ColorValidation]
        public string BackgroundColor { get; set; }

        [Required]
        [ColorValidation]
        public string FooterColor { get; set; }

        public IFormFile Logo { get; set; }

        public Currency? Currency { get; set; }
    }
}
