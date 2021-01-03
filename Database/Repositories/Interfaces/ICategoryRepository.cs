using System.Collections.Generic;
using System.Threading.Tasks;
using shop_backend.Database.Entities;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(string name, IEnumerable<string> types);
        Task DeleteAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category category, string name, IEnumerable<string> types);
    }
}