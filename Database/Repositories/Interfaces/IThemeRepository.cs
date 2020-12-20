using shop_backend.Database.Entities;
using shop_backend.ViewModels.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IThemeRepository
    {
        Task<Theme> GetAsync();
        Task UpdateAsync(UpdateThemeViewModel updateThemeViewModel);
    }
}
