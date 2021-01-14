using System.Threading.Tasks;
using shop_backend.Database.Entities;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IPurchaseSettingsRepository
    {
        Task<PurchaseSettings> GetAsync();
        Task UpdateAsync(PurchaseSettings purchaseSettings, UpdatePurchaseSettingsViewModel updatePurchaseSettingsViewModel);
    }
}