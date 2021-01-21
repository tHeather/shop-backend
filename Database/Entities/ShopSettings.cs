using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_backend.Database.Entities.Enums;

namespace shop_backend.Database.Entities
{
    public class ShopSettings
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        public string LeadingColor { get; set; }

        public string SecondaryColor { get; set; }

        public string NavbarColor { get; set; }

        public string BackgroundColor { get; set; }

        public string FooterColor { get; set; }

        public Currency Currency { get; set; }
    }
}
