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

        public int ThemeId { get; set; }

        public string Logo { get; set; }

        public Currency Currency { get; set; }

        public string Regulations { get; set; }

        public Theme Theme { get; set; }
    }
}
