namespace Shared.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(string base64ImageString, string fileName, Guid auctionId);
        Task<string> GetImageBase64StringAsync(string filePath);
        Task<byte[]> GetImageBytesAsync(string auctionId, string fileName);
    }
}
