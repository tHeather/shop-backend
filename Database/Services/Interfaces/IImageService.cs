using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ShopBackend.BusinessLogic.Services.Interfaces
{
    public interface IImageService 
    {
        Task<string> SaveImageAsync(IFormFile formFile);
        void DeleteFile(string fileName);
        Task UpdateLogoAsync(IFormFile formFile);
    }
}