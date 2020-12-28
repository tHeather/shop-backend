using System.Collections.Generic;
using System.Linq;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetSectionViewModel
    {
        public GetSectionViewModel(Section section)
        {
            Id = section.Id;
            Title = section.Title;
            Products.AddRange(section.Products.Select(p => new GetProductViewModel(p)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<GetProductViewModel> Products { get; set; } = new List<GetProductViewModel>();
    }
}
