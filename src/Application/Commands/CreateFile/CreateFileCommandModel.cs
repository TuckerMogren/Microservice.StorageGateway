namespace Microservice.StorageGateway.Application.Commands.CreateFile;
public class CreateFileCommandModel
{
    public Stream FileStream { get; init; } = default!;
    public string FileName { get; init; } = default!;
    public string MimeType { get; init; } = default!;
    public string? ParentFolderId { get; init; }
}