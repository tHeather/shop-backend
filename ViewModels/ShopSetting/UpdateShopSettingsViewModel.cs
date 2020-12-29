using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels.Theme
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
        public string TertiaryColor { get; set; }

        public IFormFile Logo { get; set; }

        public Currency? Currency { get; set; }
    }
}
