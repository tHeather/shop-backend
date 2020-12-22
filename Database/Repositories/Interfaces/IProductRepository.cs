using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces 
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string? search, string? type, string? manufacturer,
            bool isOnDiscount, int? priceMin, int? priceMax, SortType? sortType);
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(CreateProductViewModel createProductViewModel);
        Task DeleteAsync(int id);
        Task<Product> UpdateAsync(int id, UpdateProductViewModel updateProductViewModel);
    }
}