using shop_backend.Database.Entities;

namespace shop_backend.ViewModels
{
    public class GetPersonalPickupBranchViewModel
    {
        public GetPersonalPickupBranchViewModel(PersonalPickupBranch personalPickupBranch)
        {
            Id = personalPickupBranch.Id;
            Name = personalPickupBranch.Name;
            Address = personalPickupBranch.Address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
