using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories
{
    public class ShopSettingsRepository : IShopSettingsRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IImageService imageService;

        public ShopSettingsRepository(ApplicationDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task<ShopSettings> GetAsync()
        {
            return await context.ShopSettings.Include(sp => sp.Theme).SingleOrDefaultAsync();
        }

        public async Task<ShopSettings> UpdateAsync(UpdateShopSettingsViewModel  updateShopSettingsViewModel)
        {
            var theme = await context.ShopSettings.SingleOrDefaultAsync();

            if (updateShopSettingsViewModel.Logo != null)
            {
                theme.Logo = await imageService.UpdateLogoAsync(updateShopSettingsViewModel.Logo);
            }

            if(updateShopSettingsViewModel.Currency.HasValue)
            {
                theme.Currency = updateShopSettingsViewModel.Currency.Value;
            }

            if(string.IsNullOrEmpty(updateShopSettingsViewModel.Regulations))
            {
                theme.Regulations = updateShopSettingsViewModel.Regulations;
            }

            theme.ThemeId = updateShopSettingsViewModel.ThemeId;

            await context.SaveChangesAsync();

            theme.Theme = await context.Themes.SingleOrDefaultAsync(t => t.Id == theme.ThemeId);

            return theme;
        }

        public async Task<List<GetThemeViewModel>> GetAllThemes()
        {
            return await context.Themes.Select(t => new GetThemeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
        } 
    }
}
