// Application Layer
// File: Application/Interfaces/Messaging/IDeleteFileCommandDispatcher.cs

using Microservice.StorageGateway.Application.Commands.DeleteFile;

namespace Microservice.StorageGateway.Application.Commands;

public interface IDeleteFileCommandDispatcher
{
    Task<bool> SendDeleteFileAsync(DeleteFileCommandModel model, CancellationToken cancellationToken = default);
}