using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IImageService 
    {
        bool ImageExists(string fileName);
        Task<string> SaveImageAsync(IFormFile formFile);
        void DeleteFile(string fileName);
        Task<string> UpdateFileAsync(IFormFile formFile, string fileName);
    }
}