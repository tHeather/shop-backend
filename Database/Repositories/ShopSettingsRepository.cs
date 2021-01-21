﻿using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels;
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
            return await context.ShopSettings.SingleOrDefaultAsync();
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

            theme.LeadingColor = updateShopSettingsViewModel.LeadingColor;
            theme.SecondaryColor = updateShopSettingsViewModel.SecondaryColor;
            theme.NavbarColor = updateShopSettingsViewModel.NavbarColor;
            theme.BackgroundColor = updateShopSettingsViewModel.BackgroundColor;
            theme.FooterColor = updateShopSettingsViewModel.FooterColor;

            await context.SaveChangesAsync();

            return theme;
        }
    }
}
