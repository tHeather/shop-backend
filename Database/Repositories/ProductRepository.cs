using Microsoft.EntityFrameworkCore;
using ShopBackend.BusinessLogic.Database;
using ShopBackend.BusinessLogic.Entities;
using ShopBackend.BusinessLogic.Entities.Enums;
using ShopBackend.BusinessLogic.Repositories.Interfaces;
using ShopBackend.BusinessLogic.Services.Interfaces;
using ShopBackend.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBackend.BusinessLogic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IImageService imageService;

        public ProductRepository(ApplicationDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task<List<Product>> GetAllAsync(string search, string type, string manufacturer,
            bool isOnDiscount, int? priceMin , int? priceMax, SortType? sortType) 
        {
            IQueryable<Product> result = sortType switch
            {
                SortType.NameAscending => context.Products.OrderBy(p => p.Name),
                SortType.QuantityAscending => context.Products.OrderBy(p => p.Quantity),
                SortType.PriceAscending => context.Products.OrderBy(p => p.Price),
                SortType.QuantityDescending => context.Products.OrderByDescending(p => p.Quantity),
                SortType.PriceDescending => context.Products.OrderByDescending(p => p.Price),
                _ => context.Products.OrderByDescending(p => p.Name),
            };

            if (priceMin != null && priceMax != null )
                result = result.Where(p => p.Price >= priceMin && p.Price <= priceMax);

            if (manufacturer != null)
                result = result.Where(p => p.Manufacturer == manufacturer);

            if (isOnDiscount)
                result = result.Where(p => p.IsOnDiscount);

            if (type != null)
                result = result.Where(p => p.Type == type);

            if (search != null)
            {
                var upperCaseSearch = search.ToUpper();
                result = result.Where(p =>
                    p.Name.ToUpper().Contains(upperCaseSearch) ||
                    p.Type.ToUpper().Contains(upperCaseSearch) ||
                    p.Manufacturer.ToUpper().Contains(upperCaseSearch) ||
                    p.Description.ToUpper().Contains(upperCaseSearch));
            }


            return await result.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateAsync(CreateProductViewModel createProductViewModel)
        {
            var product = createProductViewModel.MapToEntity();

            if(createProductViewModel.FirstImage != null)
                product.FirstImage = await imageService.SaveImageAsync(createProductViewModel.FirstImage);

            if (createProductViewModel.SecondImage != null)
                product.SecondImage = await imageService.SaveImageAsync(createProductViewModel.SecondImage);

            if (createProductViewModel.ThirdImage != null)
                product.ThirdImage = await imageService.SaveImageAsync(createProductViewModel.ThirdImage);

            context.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await context.Products.SingleOrDefaultAsync(p => p.Id == id);
            context.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(int id, UpdateProductViewModel updateProductViewModel)
        {
            var product = await context.Products.SingleOrDefaultAsync(p => p.Id == id);

            if(updateProductViewModel.FirstImage != null)
            {
                if(product.FirstImage != null)
                    imageService.DeleteFile(product.FirstImage);

                product.FirstImage = await imageService.SaveImageAsync(updateProductViewModel.FirstImage);
            }

            if (updateProductViewModel.SecondImage != null)
            {
                if (product.SecondImage != null)
                    imageService.DeleteFile(product.SecondImage);

                product.SecondImage = await imageService.SaveImageAsync(updateProductViewModel.SecondImage);
            }

            if (updateProductViewModel.ThirdImage != null)
            {
                if (product.ThirdImage != null)
                    imageService.DeleteFile(product.ThirdImage);

                product.ThirdImage = await imageService.SaveImageAsync(updateProductViewModel.ThirdImage);
            }

            product.Name = updateProductViewModel.Name;
            product.Type = updateProductViewModel.Type;
            product.Manufacturer = updateProductViewModel.Manufacturer;
            product.Description = updateProductViewModel.Description;
            product.Quantity = updateProductViewModel.Quantity;
            product.Price = updateProductViewModel.Price;
            product.IsOnDiscount = updateProductViewModel.IsOnDiscount;
            product.DiscountPrice = updateProductViewModel.DiscountPrice;

            await context.SaveChangesAsync();

            return product;
        }
    }
}