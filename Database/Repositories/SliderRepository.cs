using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IImageService imageService;

        public SliderRepository(ApplicationDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task<Slider> GetAsync()
        {
            return await context.Sliders.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Slider slider, UpdateSliderViewModel updateSliderViewModel)
        {
            //var savingTasks = new List<Task<string>>
            //{
            //    imageService.SaveImageAsync(updateSliderViewModel.FirstSlide),
            //    imageService.SaveImageAsync(updateSliderViewModel.SecondSlide),
            //    imageService.SaveImageAsync(updateSliderViewModel.ThirdSlide),
            //    imageService.SaveImageAsync(updateSliderViewModel.FourthSlide),
            //    imageService.SaveImageAsync(updateSliderViewModel.FifthSlide)
            //};

            //var result = await Task.WhenAll(savingTasks);
            //slider.FirstSlide = result[0];
            //slider.SecondSlide = result[1];
            //slider.ThirdSlide = result[2];
            //slider.FourthSlide = result[3];
            //slider.FifthSlide = result[4];

            if (updateSliderViewModel.FirstSlide != null)
                slider.FirstSlide = await imageService.SaveImageAsync(updateSliderViewModel.FirstSlide);

            if (updateSliderViewModel.SecondSlide != null)
                slider.SecondSlide = await imageService.SaveImageAsync(updateSliderViewModel.SecondSlide);

            if (updateSliderViewModel.ThirdSlide != null)
                slider.ThirdSlide = await imageService.SaveImageAsync(updateSliderViewModel.ThirdSlide);

            if (updateSliderViewModel.FourthSlide != null)
                slider.FourthSlide = await imageService.SaveImageAsync(updateSliderViewModel.FourthSlide);

            if (updateSliderViewModel.FifthSlide != null)
                slider.FifthSlide = await imageService.SaveImageAsync(updateSliderViewModel.FifthSlide);

            await context.SaveChangesAsync();
        }
    }
}
