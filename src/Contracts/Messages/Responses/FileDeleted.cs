namespace Microservice.StorageGateway.Contracts.Messages.Responses;

public interface FileDeleted
{
    Ulid CorrelationId { get; }
}
