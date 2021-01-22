namespace shop_backend.Database.Entities
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondaryBackgroundColor { get; set; }
        public string SecondaryTextColor { get; set; }
        public string LeadingBackgroundColor { get; set; }
        public string LeadingTextColor { get; set; }
        public string NavbarBackgroundColor { get; set; }
        public string NavbarTextColor { get; set; }
        public string MainBackgroundColor { get; set; }
        public string MainTextColor { get; set; }
        public string FooterBackgroundColor { get; set; }
        public string FooterTextColor { get; set; }
    }
}
