using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories
{
    public class PersonalPickupBranchRepository : IPersonalPickupBranchRepository
    {
        private readonly ApplicationDbContext context;

        public PersonalPickupBranchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PersonalPickupBranch> GetByIdAsync(int id)
        {
            return await context.PersonalPickupBranches.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PersonalPickupBranch>> GetAllAsync()
        {
            return await context.PersonalPickupBranches.ToListAsync();
        }

        public async Task CreateAsync(CreatePersonalPickupBranchViewModel createPersonalPickupBranchViewModel)
        {
            var newBranch = new PersonalPickupBranch
            {
                Name = createPersonalPickupBranchViewModel.Name,
                Address = createPersonalPickupBranchViewModel.Address
            };

            context.PersonalPickupBranches.Add(newBranch);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonalPickupBranch personalPickupBranch, UpdatePersonalPickupBranchViewModel updatePersonalPickupBranchViewModel)
        {
            personalPickupBranch.Name = updatePersonalPickupBranchViewModel.Name;
            personalPickupBranch.Address = updatePersonalPickupBranchViewModel.Address;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PersonalPickupBranch personalPickupBranch)
        {
            context.Remove(personalPickupBranch);
            await context.SaveChangesAsync();
        }
    }
}
