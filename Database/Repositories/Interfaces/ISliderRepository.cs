using System.Threading.Tasks;
using shop_backend.Database.Entities;
using shop_backend.ViewModels;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface ISliderRepository
    {
        Task<Slider> GetAsync();
        Task UpdateAsync(Slider slider, UpdateSliderViewModel updateSliderViewModel);
    }
}