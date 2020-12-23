using Microsoft.EntityFrameworkCore;
using ShopBackend.BusinessLogic.Database;
using ShopBackend.BusinessLogic.Entities;
using ShopBackend.BusinessLogic.Repositories.Interfaces;
using ShopBackend.BusinessLogic.Services.Interfaces;
using ShopBackend.BusinessLogic.ViewModels;
using System.Threading.Tasks;

namespace ShopBackend.BusinessLogic.Repositories
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
