using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CRUD.Configuration.Library
{
    public static class ImageProcess
    {
        public static async Task<string> ProcessUploadImages(IFormFile image, string filePath)
        {
            string uniqueFileName = null;
            if(image!=null && image.Length > 0)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string location = Path.Combine(filePath, uniqueFileName);

                using (var stream = File.Create(location))
                {
                    await image.CopyToAsync(stream);
                }
            }
            return uniqueFileName;
        }

        public static void ProcessDeleteImages(string filePath)
        {
            File.Delete(filePath);
        }

        public static string GitFilePath(string directory, string filePath)
        {
            return Path.Combine(directory, filePath);
        }
    }
}
