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
                theme.Logo = await imageService.UpdateFileAsync(updateShopSettingsViewModel.Logo,"logo");
            }

            if(updateShopSettingsViewModel.Currency.HasValue)
            {
                theme.Currency = updateShopSettingsViewModel.Currency.Value;
            }

            if (updateShopSettingsViewModel.Regulations != null)
            {
                theme.Regulations = await imageService.UpdateFileAsync(updateShopSettingsViewModel.Regulations, "regulations");
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

        public async Task<bool> DeleteLogo()
        {
            var settings = await context.ShopSettings.SingleOrDefaultAsync();
            if (settings.Logo == "") return false;
            if (!imageService.ImageExists(settings.Logo)) return false;

            imageService.DeleteFile(settings.Logo);
            settings.Logo = "";
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRegulations()
        {
            var settings = await context.ShopSettings.SingleOrDefaultAsync();
            if (settings.Regulations == "") return false;
            if (!imageService.ImageExists(settings.Regulations)) return false;

            imageService.DeleteFile(settings.Regulations);
            settings.Regulations = "";
            await context.SaveChangesAsync();

            return true;
        }

    }
}
