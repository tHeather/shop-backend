using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetFooterSettingsViewModel
    {
        public GetFooterSettingsViewModel(FooterSettings footerSettings)
        {
            WeekWorkingHours = footerSettings.WeekWorkingHours;
            WeekendWorkingHours = footerSettings.WeekendWorkingHours;
            PhoneNumber = footerSettings.PhoneNumber;
            Email = footerSettings.Email;
            Text = footerSettings.Text;
        }

        public string WeekWorkingHours { get; set; }
        public string WeekendWorkingHours { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
