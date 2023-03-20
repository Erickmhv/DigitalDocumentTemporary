using System.Drawing;
using Microsoft.Extensions.Options;
using Shared.Interfaces;
using Shared.SettingsModels;

namespace Shared.Helpers
{
    public class FileService : IFileService
    {
        private readonly FileServiceSettings _fileServiceSettings;

        public FileService(IOptions<FileServiceSettings> fileServiceSettings)
        {
            _fileServiceSettings = fileServiceSettings.Value;
        }

        public Task<string> SaveFileAsync(string base64ImageString, string fileName, Guid auctionId)
        {
            base64ImageString = base64ImageString.Substring(base64ImageString.IndexOf(",") + 1);

            byte[] bytes = Convert.FromBase64String(base64ImageString);

            string imageDirectory = Path.Combine(_fileServiceSettings.ImagesRootFolder, auctionId.ToString());
            
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            string fullImagePath = Path.Combine(imageDirectory, fileName);

            File.WriteAllBytes(fullImagePath, bytes);

            return Task.FromResult(fullImagePath);
        }

        public async Task<string> GetImageBase64StringAsync(string filePath)
        {
            byte[] imageArray = await File.ReadAllBytesAsync(filePath);

            return Convert.ToBase64String(imageArray);
        }

        public async Task<byte[]> GetImageBytesAsync(string auctionId, string fileName)
        {
            string filePath = Path.Join(_fileServiceSettings.ImagesRootFolder, auctionId, fileName);

            return await File.ReadAllBytesAsync(filePath);
        }
    }
}
