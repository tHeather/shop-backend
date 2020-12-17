using Microsoft.AspNetCore.Http;
using shop_backend.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Services
{
    public class ImageService : IImageService
    {
        private readonly string filesRootFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public async Task<string> SaveFileAsync(IFormFile formFile)
        {
            var fileExtension = formFile.ContentType.Split('/').Skip(1).ToArray()[0];
            var fileName = $"{Guid.NewGuid()}.{fileExtension}";
            var imagePath = Path.Combine(filesRootFolderPath, fileName);
            using(var stream = new FileStream(imagePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            
            return fileName;
        }

        public void DeleteFile(string fileName)
        {
            var fullPath = Path.Combine(filesRootFolderPath, fileName);
            File.Delete(fullPath);
        }
    }
}