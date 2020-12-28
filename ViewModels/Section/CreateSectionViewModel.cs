using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shop_backend.ViewModels
{
    public class CreateSectionViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public List<int> ProductIds { get; set; }
    }
}
