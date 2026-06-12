using Leads.Domain.Interfaces.Services;
using Leads.Infra.Storage.Enum;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Leads.Infra.Storage.Service;

public class StorageService(IMinioClient minioClient) : IStorageService
{

    private async Task ExistBucketAsync()
    {
        if (!await minioClient.BucketExistsAsync(
                new BucketExistsArgs()
                    .WithBucket(EStorageBuckets.properties.ToString())))
        {
            throw new InvalidBucketNameException();
        }
    }
    
    public async Task<string> UploadAsync(Stream stream, string fileName, string contentType, string folder)
    {
        await ExistBucketAsync();
        
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        var storagePath = $"{folder}/{Guid.NewGuid()}{extension}";

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(EStorageBuckets.properties.ToString())
            .WithObject(storagePath)
            .WithStreamData(stream)
            .WithObjectSize(stream.Length)
            .WithContentType(contentType));

        return storagePath;
    }

    public async Task<string> GetVirtualPathAsync(string storagePath)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
            throw new ArgumentNullException(nameof(storagePath));

        return await minioClient.PresignedGetObjectAsync(
            new PresignedGetObjectArgs()
                .WithBucket(EStorageBuckets.properties.ToString())
                .WithObject(storagePath)
                .WithExpiry(3600));
    }

    public async Task DeleteAsync(string storagePath)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
            throw new ArgumentNullException(nameof(storagePath));
        
        await minioClient.RemoveObjectAsync(
            new RemoveObjectArgs()
                .WithBucket(EStorageBuckets.properties.ToString())
                .WithObject(storagePath));
    }

    public async Task DeleteManyAsync(IEnumerable<string> storagePaths)
    {
        var objects = storagePaths.ToList();

        if (!objects.Any()) return;
        
        await minioClient.RemoveObjectsAsync(
            new RemoveObjectsArgs()
                .WithBucket(EStorageBuckets.properties.ToString())
                .WithObjects(objects));
    }
}