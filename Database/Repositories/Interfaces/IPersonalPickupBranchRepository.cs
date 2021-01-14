using System.Collections.Generic;
using System.Threading.Tasks;
using shop_backend.Database.Entities;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IPersonalPickupBranchRepository
    {
        Task<PersonalPickupBranch> GetByIdAsync(int id);
        Task CreateAsync(CreatePersonalPickupBranchViewModel createPersonalPickupBranchViewModel);
        Task DeleteAsync(PersonalPickupBranch personalPickupBranch);
        Task<List<PersonalPickupBranch>> GetAllAsync();
        Task UpdateAsync(PersonalPickupBranch personalPickupBranch, UpdatePersonalPickupBranchViewModel updatePersonalPickupBranchViewModel);
    }
}