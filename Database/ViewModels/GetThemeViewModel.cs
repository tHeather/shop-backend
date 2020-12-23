using ShopBackend.BusinessLogic.Entities;

namespace ShopBackend.BusinessLogic.ViewModels
{
    public class GetThemeViewModel
    {
        public GetThemeViewModel(Theme theme)
        {
            LeadingColor = theme.LeadingColor;
            SecondaryColor = theme.SecondaryColor;
            TertiaryColor = theme.TertiaryColor;
        }

        public string LeadingColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TertiaryColor { get; set; }

    }
}
