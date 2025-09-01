using Microsoft.Extensions.Logging;

namespace Microservice.StorageGateway.Application.Commands.CreateFile;

public class CreateFileCommandHandler(ICreateFileCommandDispatcher dispatcher, ILogger<CreateFileCommandHandler> logger) : ICreateFileCommandHandler
{
    private readonly ICreateFileCommandDispatcher _dispatcher = dispatcher;
    private readonly ILogger<CreateFileCommandHandler> _logger = logger;

    public Task<string> HandleAsync(CreateFileCommandModel command, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation( "Sending: {MethodName}", nameof(_dispatcher.SendCreateFileAsync));
        return _dispatcher.SendCreateFileAsync(command, cancellationToken);
    }
}