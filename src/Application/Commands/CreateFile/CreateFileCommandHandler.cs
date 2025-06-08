
namespace Microservice.StorageGateway.Application.Commands.CreateFile;

public class CreateFileCommandHandler(IFileCommandDispatcher dispatcher) : ICreateFileCommandHandler
{
    private readonly IFileCommandDispatcher _dispatcher = dispatcher;

    public Task<string> HandleAsync(CreateFileCommandModel command, CancellationToken cancellationToken = default)
    {
        return _dispatcher.SendCreateFileAsync(command, cancellationToken);
    }
}