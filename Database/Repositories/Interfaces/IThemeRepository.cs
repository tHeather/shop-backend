using ShopBackend.BusinessLogic.Entities;
using ShopBackend.BusinessLogic.ViewModels;
using System.Threading.Tasks;

namespace ShopBackend.BusinessLogic.Repositories.Interfaces
{
    public interface IThemeRepository
    {
        Task<Theme> GetAsync();
        Task UpdateAsync(UpdateThemeViewModel updateThemeViewModel);
    }
}
