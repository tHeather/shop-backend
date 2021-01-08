using System.Threading.Tasks;
using shop_backend.Database.Entities;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IFooterSettingsRepository
    {
        Task<FooterSettings> GetAsync();
        Task UpdateAsync(FooterSettings footerSettings, UpdateFooterSettingsViewModel updateFooterSettingsViewModel);
    }
}