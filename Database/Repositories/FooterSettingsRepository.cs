using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories
{
    public class FooterSettingsRepository : IFooterSettingsRepository
    {
        private readonly ApplicationDbContext context;

        public FooterSettingsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<FooterSettings> GetAsync()
        {
            return await context.FooterSettings.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(FooterSettings footerSettings, UpdateFooterSettingsViewModel updateFooterSettingsViewModel)
        {
            footerSettings.WeekWorkingHours = updateFooterSettingsViewModel.WeekWorkingHours;
            footerSettings.WeekendWorkingHours = updateFooterSettingsViewModel.WeekendWorkingHours;
            footerSettings.Email = updateFooterSettingsViewModel.Email;
            footerSettings.PhoneNumber = updateFooterSettingsViewModel.PhoneNumber;
            footerSettings.Text = updateFooterSettingsViewModel.Text;

            await context.SaveChangesAsync();
        }
    }
}
