using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.ViewModels
{
    public class GetShopSettingViewModel
    {
        public GetShopSettingViewModel(ShopSettings shopSettings)
        {
            Logo = shopSettings.Logo;
            LeadingColor = shopSettings.LeadingColor;
            SecondaryColor = shopSettings.SecondaryColor;
            TertiaryColor = shopSettings.TertiaryColor;
            Currency = shopSettings.Currency;
        }

        public string Logo { get; set; }

        public string LeadingColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TertiaryColor { get; set; }

        public Currency Currency { get; set; }
    }
}
