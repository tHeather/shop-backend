using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBackend.BusinessLogic.Entities;
using ShopBackend.BusinessLogic.Entities.Enums;
using ShopBackend.BusinessLogic.ViewModels;

namespace ShopBackend.BusinessLogic.Repositories.Interfaces 
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string search, string type, string manufacturer,
            bool isOnDiscount, int? priceMin, int? priceMax, SortType? sortType);
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(CreateProductViewModel createProductViewModel);
        Task DeleteAsync(int id);
        Task<Product> UpdateAsync(int id, UpdateProductViewModel updateProductViewModel);
    }
}