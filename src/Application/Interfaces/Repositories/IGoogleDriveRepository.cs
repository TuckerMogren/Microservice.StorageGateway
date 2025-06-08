using Microservice.StorageGateway.Application.Models.GoogleDrive;

namespace Microservice.StorageGateway.Application.Interfaces.Repositories;

public interface IGoogleDriveRepository
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string mimeType, string? parentFolderId = null);
    Task<Stream> DownloadFileAsync(string fileId);
    Task DeleteFileAsync(string fileId);
    Task<IList<GoogleFileMetadata>> ListFilesAsync(string? parentFolderId = null);
    Task<GoogleFileMetadata?> GetFileMetadataAsync(string fileId);
}
