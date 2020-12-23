using Microsoft.AspNetCore.Http;
using ShopBackend.BusinessLogic.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBackend.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private readonly string filesRootFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public async Task<string> SaveImageAsync(IFormFile formFile)
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

        public async Task UpdateLogoAsync(IFormFile formFile) 
        {
            var fileExtension = formFile.ContentType.Split('/').Skip(1).ToArray()[0];
            var fileName = $"logo.{fileExtension}";
            var logoPath = Path.Combine(filesRootFolderPath, fileName);

            if(File.Exists(logoPath))
            {
                File.Delete(logoPath);
            }

            using (var stream = new FileStream(logoPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
        }
    }
}