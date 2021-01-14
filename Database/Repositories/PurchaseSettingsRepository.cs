using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories
{
    public class PurchaseSettingsRepository : IPurchaseSettingsRepository
    {
        private readonly ApplicationDbContext context;

        public PurchaseSettingsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PurchaseSettings> GetAsync()
        {
            return await context.PurchaseSettings.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(PurchaseSettings purchaseSettings, UpdatePurchaseSettingsViewModel updatePurchaseSettingsViewModel)
        {
            purchaseSettings.IsCashAvaible = updatePurchaseSettingsViewModel.IsCashAvaible;
            purchaseSettings.IsDotpayAvaible = updatePurchaseSettingsViewModel.IsDotpayAvaible;
            purchaseSettings.IsPersonalPickupAvaible = updatePurchaseSettingsViewModel.IsPersonalPickupAvaible;
            purchaseSettings.IsShippingAvaible = updatePurchaseSettingsViewModel.IsShippingAvaible;
            purchaseSettings.IsTransferAvaible = updatePurchaseSettingsViewModel.IsTransferAvaible;

            if(updatePurchaseSettingsViewModel.IsTransferAvaible)
                purchaseSettings.TransferNumber = updatePurchaseSettingsViewModel.TransferNumber;

            await context.SaveChangesAsync();
        }
    }
}
