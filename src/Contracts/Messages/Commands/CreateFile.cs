// CreateFile.cs
namespace Microservice.StorageGateway.Contracts.Messages.Commands;

public interface CreateFile
{
    Guid CorrelationId { get; }
    string FileName { get; }
    string MimeType { get; }
    byte[] FileBytes { get; }
    string? ParentFolderId { get; }
}