namespace Leads.Domain.Interfaces.Services;

public interface IStorageService
{
    Task<string> UploadAsync(Stream stream, string fileName, string contentType, string folder);
    Task<string> GetVirtualPathAsync(string storagePath);
    Task DeleteAsync(string storagePath);
    Task DeleteManyAsync(IEnumerable<string> storagePaths);
}