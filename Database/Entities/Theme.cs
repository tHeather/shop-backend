using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Database.Entities
{
    public class Theme
    {
        public int Id { get; set; }

        public string LeadingColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TertiaryColor { get; set; }

    }
}
