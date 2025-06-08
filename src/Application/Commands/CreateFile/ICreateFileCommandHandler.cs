namespace Microservice.StorageGateway.Application.Commands.CreateFile;

public interface ICreateFileCommandHandler
{
    Task<string> HandleAsync(CreateFileCommandModel command, CancellationToken cancellationToken = default);
}