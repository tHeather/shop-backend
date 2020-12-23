using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories
{
    public class ThemeRepository: IThemeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IImageService imageService;

        public ThemeRepository(ApplicationDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task<Theme> GetAsync()
        {
            return await context.Themes.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(UpdateThemeViewModel  updateThemeViewModel )
        {
            var theme = await context.Themes.SingleOrDefaultAsync();

            if (updateThemeViewModel.Logo != null)
            {
                await imageService.UpdateLogoAsync(updateThemeViewModel.Logo);
            }

            theme.LeadingColor = updateThemeViewModel.LeadingColor;
            theme.SecondaryColor = updateThemeViewModel.SecondaryColor;
            theme.TertiaryColor = updateThemeViewModel.TertiaryColor;

            await context.SaveChangesAsync();
        }
    }
}
