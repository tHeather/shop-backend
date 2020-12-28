using System;
using System.Collections.Generic;

namespace shop_backend.Database.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
