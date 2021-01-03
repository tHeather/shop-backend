using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Helpers;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces 
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAllAsync(int pageNumber, string search, string type, string manufacturer,
            bool isOnDiscount, int? priceMin, int? priceMax, SortType? sortType);
        Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids);
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(CreateProductViewModel createProductViewModel);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product, UpdateProductViewModel updateProductViewModel);
        Task SaveChangesAsync();
        Task<List<string>> GetAllProductTypes();
    }
}