using System.Collections.Generic;
using System.Linq;
using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetSectionNameViewModel
    {
        public GetSectionNameViewModel(Section section)
        {
            Id = section.Id;
            Title = section.Title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}
