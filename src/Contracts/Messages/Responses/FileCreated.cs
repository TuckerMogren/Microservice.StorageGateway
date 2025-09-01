// FileCreated.cs
namespace Microservice.StorageGateway.Contracts.Messages.Responses;

public interface FileCreated
{
    Ulid CorrelationId { get; }
    string FileId { get; }
    string FolderId { get; }
}