// Application Layer
// File: Application/Interfaces/Messaging/ICreateFileCommandDispatcher.cs

using Microservice.StorageGateway.Application.Commands.CreateFile;

namespace Microservice.StorageGateway.Application.Commands;

public interface ICreateFileCommandDispatcher
{
    Task<string> SendCreateFileAsync(CreateFileCommandModel model, CancellationToken cancellationToken = default);
}
