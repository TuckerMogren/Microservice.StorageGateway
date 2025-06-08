using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Application.Models.GoogleDrive;

namespace Microservice.StorageGateway.Persistence.GoogleDrive;

public class GoogleDriveRepository : IGoogleDriveRepository
{
    private readonly DriveService _driveService;

    public GoogleDriveRepository(GoogleCredential credential)
    {
        _driveService = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "StorageGateway"
        });
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string mimeType, string? parentFolderId = null)
    {
        var fileMetadata = new Google.Apis.Drive.v3.Data.File
        {
            Name = fileName,
            Parents = parentFolderId is not null ? new[] { parentFolderId } : null
        };

        var request = _driveService.Files.Create(fileMetadata, fileStream, mimeType);
        request.Fields = "id";
        var file = await request.UploadAsync();

        if (file.Status != Google.Apis.Upload.UploadStatus.Completed)
            throw new IOException("File upload failed.");

        return request.ResponseBody.Id;
    }

    public async Task<Stream> DownloadFileAsync(string fileId)
    {
        var stream = new MemoryStream();
        var request = _driveService.Files.Get(fileId);
        await request.DownloadAsync(stream);
        stream.Position = 0;
        return stream;
    }

    public async Task DeleteFileAsync(string fileId)
    {
        var request = _driveService.Files.Delete(fileId);
        await request.ExecuteAsync();
    }

    public async Task<IList<GoogleFileMetadata>> ListFilesAsync(string? parentFolderId = null)
    {
        var request = _driveService.Files.List();
        request.Q = parentFolderId is not null ? $"'{parentFolderId}' in parents" : null;
        request.Fields = "files(id, name, mimeType, size)";
        var result = await request.ExecuteAsync();

        return result.Files.Select(f => new GoogleFileMetadata(f.Id, f.Name, f.MimeType, f.Size)).ToList();
    }

    public async Task<GoogleFileMetadata?> GetFileMetadataAsync(string fileId)
    {
        var file = await _driveService.Files.Get(fileId).ExecuteAsync();
        return new GoogleFileMetadata(file.Id, file.Name, file.MimeType, file.Size);
    }
}
