using System.ComponentModel.DataAnnotations;

namespace shop_backend.ViewModels
{
    public class UpdateFooterSettingsViewModel
    {
        [Required]
        public string WeekWorkingHours { get; set; }

        [Required]
        public string WeekendWorkingHours { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
