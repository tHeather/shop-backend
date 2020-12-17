using shop_backend.Database.Entities;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces 
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(CreateProductViewModel createProductViewModel);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UpdateProductViewModel updateProductViewModel);
    }
}