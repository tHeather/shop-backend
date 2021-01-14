using shop_backend.Database.Entities;
using shop_backend.ViewModels;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IShopSettingsRepository
    {
        Task<ShopSettings> GetAsync();
        Task<ShopSettings> UpdateAsync(UpdateShopSettingsViewModel updateShopSettingsViewModel);
    }
}
