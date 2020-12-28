using System.Collections.Generic;
using System.Threading.Tasks;
using shop_backend.Database.Entities;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface ISectionRepository
    {
        Task CreateAsync(string title, ICollection<Product> products);
        Task<Section> GetById(int id);
        Task DeleteAsync(Section section);
        Task<List<Section>> GetAllAsync();
        Task UpdateAsync(string title, Section section, ICollection<Product> products);
    }
}