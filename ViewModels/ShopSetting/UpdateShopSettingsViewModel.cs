using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using shop_backend.Attributes;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class UpdateShopSettingsViewModel
    {
        [Required]
        public int ThemeId { get; set; }

        public IFormFile Regulations { get; set; }

        public IFormFile Logo { get; set; }

        public Currency? Currency { get; set; }
    }
}
