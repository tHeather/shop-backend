using shop_backend.Database.Entities;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IShopSettingsRepository
    {
        Task<ShopSettings> GetAsync();
        Task<ShopSettings> UpdateAsync(UpdateShopSettingsViewModel updateShopSettingsViewModel);
        Task<List<GetThemeViewModel>> GetAllThemes();
        Task<bool> DeleteLogo();
        Task<bool> DeleteRegulations();
    }
}
