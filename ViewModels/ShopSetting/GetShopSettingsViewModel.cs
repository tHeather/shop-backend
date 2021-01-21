using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class GetShopSettingsViewModel
    {
        public GetShopSettingsViewModel(ShopSettings shopSettings)
        {
            Logo = shopSettings.Logo;
            LeadingColor = shopSettings.LeadingColor;
            SecondaryColor = shopSettings.SecondaryColor;
            NavbarColor = shopSettings.NavbarColor;
            BackgroundColor = shopSettings.BackgroundColor;
            FooterColor = shopSettings.FooterColor;
            Currency = shopSettings.Currency;
        }

        public string Logo { get; set; }

        public string LeadingColor { get; set; }

        public string SecondaryColor { get; set; }

        public string NavbarColor { get; set; }

        public string BackgroundColor { get; set; }

        public string FooterColor { get; set; }

        public Currency Currency { get; set; }
    }
}
