using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class GetShopSettingsViewModel
    {
        public GetShopSettingsViewModel(ShopSettings shopSettings)
        {
            Theme = shopSettings.Theme;
            Logo = shopSettings.Logo;
            Currency = shopSettings.Currency;
            Regulations = shopSettings.Regulations;
        }

        public Theme Theme { get; set; }

        public string Logo { get; set; }

        public Currency Currency { get; set; }

        public string Regulations { get; set; }
    }
}
