using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IImageService 
    {
        Task<string> SaveFileAsync(IFormFile formFile);
        void DeleteFile(string fileName);
    }
}