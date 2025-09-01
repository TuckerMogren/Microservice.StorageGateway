using System;

namespace Microservice.StorageGateway.Contracts.Messages.Commands;

public interface DeleteFile
{
    Ulid CorrelationId { get; }
    public string FileId { get; }
}
