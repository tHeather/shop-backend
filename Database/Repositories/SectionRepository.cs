using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;

namespace shop_backend.Database.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext context;

        public SectionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Section>> GetAllAsync()
        {
            return await context.Sections.ToListAsync();
        }

        public async Task<List<Section>> GetAllWithProductsAsync()
        {
            return await context.Sections.Include(s => s.Products).ToListAsync();
        }

        public async Task<Section> GetById(int id)
        {
            return await context.Sections.Include(s => s.Products).SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(string title, ICollection<Product> products)
        {
            context.Add(new Section
            {
                Title = title,
                Products = products
            });
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string title, Section section, ICollection<Product> products)
        {
            section.Title = title;
            section.Products = products;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Section section)
        {
            context.Remove(section);
            await context.SaveChangesAsync();
        }
    }
}
