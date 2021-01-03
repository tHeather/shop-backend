using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shop_backend.ViewModels
{
    public class UpdateCategoryViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public List<string> Types { get; set; }
    }
}
