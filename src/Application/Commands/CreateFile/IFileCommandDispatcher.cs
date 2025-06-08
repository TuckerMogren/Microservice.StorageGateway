// Application Layer
// File: Application/Interfaces/Messaging/IFileCommandDispatcher.cs

namespace Microservice.StorageGateway.Application.Commands.CreateFile;

public interface IFileCommandDispatcher
{
    Task<string> SendCreateFileAsync(CreateFileCommandModel model, CancellationToken cancellationToken = default);
}