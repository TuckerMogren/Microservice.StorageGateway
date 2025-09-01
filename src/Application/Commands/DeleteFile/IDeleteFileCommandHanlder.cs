using System;

namespace Microservice.StorageGateway.Application.Commands.DeleteFile;

public interface IDeleteFileCommandHanlder
{
    Task<bool> HandleAsync(DeleteFileCommandModel command, CancellationToken cancellationToken = default);
}
