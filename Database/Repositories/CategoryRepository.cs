using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;

namespace shop_backend.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(string name, IEnumerable<string> types)
        {
            var category = new Category
            {
                Title = name,
                Types = JsonSerializer.Serialize(types)
            };

            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category, string name, IEnumerable<string> types)
        {
            category.Title = name;
            category.Types = JsonSerializer.Serialize(types);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
        }
    }
}
