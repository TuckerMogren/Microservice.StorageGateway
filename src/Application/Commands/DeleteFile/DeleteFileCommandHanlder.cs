using Microsoft.Extensions.Logging;

namespace Microservice.StorageGateway.Application.Commands.DeleteFile;

public class DeleteFileCommandHanlder(IDeleteFileCommandDispatcher dispatcher, ILogger<DeleteFileCommandHanlder> logger) : IDeleteFileCommandHanlder
{
    private readonly IDeleteFileCommandDispatcher _dispatcher = dispatcher;
    private readonly ILogger<DeleteFileCommandHanlder> _logger = logger;

    public async Task<bool> HandleAsync(DeleteFileCommandModel command, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation( "Sending: {MethodName}", nameof(_dispatcher.SendDeleteFileAsync));
        return await _dispatcher.SendDeleteFileAsync(command, cancellationToken);
    }
}