using System.ComponentModel.DataAnnotations;

namespace shop_backend.ViewModels
{
    public class CreatePersonalPickupBranchViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
    }
}
