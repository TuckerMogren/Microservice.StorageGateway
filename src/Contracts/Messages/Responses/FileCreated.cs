// FileCreated.cs
namespace Microservice.StorageGateway.Contracts.Messages.Responses;

public interface FileCreated
{
    Guid CorrelationId { get; }
    string FileId { get; }
}