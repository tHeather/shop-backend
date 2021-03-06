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

        public bool ImageExists(string fileName)
        {
            var filePath = Path.Combine(filesRootFolderPath, fileName);
            return File.Exists(filePath);
        }

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

        public async Task<string> UpdateFileAsync(IFormFile formFile, string fileName) 
        {
            var fileExtension = formFile.ContentType.Split('/').Skip(1).ToArray()[0];
            var fileNameWithExtension = $"{fileName}.{fileExtension}";
            var logoPath = Path.Combine(filesRootFolderPath, fileNameWithExtension);

            if(File.Exists(logoPath))
            {
                File.Delete(logoPath);
            }

            using (var stream = new FileStream(logoPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileNameWithExtension;
        }
    }
}