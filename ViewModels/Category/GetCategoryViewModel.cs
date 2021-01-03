using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetCategoryViewModel
    {
        public GetCategoryViewModel(Category category)
        {
            Id = category.Id;
            Title = category.Title;
            Types = JsonSerializer.Deserialize<ICollection<string>>(category.Types);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<string> Types { get; set; }
    }
}
