using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetThemeViewModel
    {
        public GetThemeViewModel(Database.Entities.Theme theme)
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
