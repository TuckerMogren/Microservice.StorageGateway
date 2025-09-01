using MassTransit;
using Microsoft.Extensions.Logging;
using Microservice.StorageGateway.Application.Commands.CreateFile;
using Microservice.StorageGateway.Application.Commands.DeleteFile;
using Microservice.StorageGateway.Contracts.Messages.Commands;
using Microservice.StorageGateway.Contracts.Messages.Responses;
using Microservice.StorageGateway.Application.Commands;

namespace Microservice.StorageGateway.Infrastructure.Messaging;

public class MassTransitFileCommandDispatcher(
    IRequestClient<CreateFile> createClient,
    IRequestClient<DeleteFile> deleteClient,
    ILogger<MassTransitFileCommandDispatcher> logger) : ICreateFileCommandDispatcher, IDeleteFileCommandDispatcher
{
    private readonly IRequestClient<CreateFile> _createClient = createClient;
    private readonly IRequestClient<DeleteFile> _deleteClient = deleteClient;
    private readonly ILogger<MassTransitFileCommandDispatcher> _logger = logger;

    public async Task<string> SendCreateFileAsync(CreateFileCommandModel model, CancellationToken cancellationToken = default)
    {
        using var ms = new MemoryStream();
        _logger.LogInformation("Copying stream for file '{FileName}'", model.FileName);
        await model.FileStream.CopyToAsync(ms, cancellationToken);

        var correlationId = Guid.NewGuid();
        _logger.LogInformation("Sending CreateFile message with CorrelationId {CorrelationId}", correlationId);

        var response = await _createClient.GetResponse<FileCreated>(new
        {
            CorrelationId = correlationId,
            FileName = model.FileName,
            MimeType = model.MimeType,
            FileBytes = ms.ToArray(),
            ParentFolderId = model.ParentFolderId
        }, cancellationToken);

        _logger.LogInformation("File created with ID: {FileId}", response.Message.FileId);
        return response.Message.FileId;
    }

    public async Task<bool> SendDeleteFileAsync(DeleteFileCommandModel model, CancellationToken cancellationToken = default)
    {
        var correlationId = Guid.NewGuid();
        _logger.LogInformation("Sending DeleteFile message for FileId {FileId} with CorrelationId {CorrelationId}", model.FileId, correlationId);

        var response = await _deleteClient.GetResponse<FileDeleted>(new
        {
            CorrelationId = correlationId,
            FileId = model.FileId
        }, cancellationToken);

        _logger.LogInformation("Delete confirmed for FileId {FileId}", model.FileId);
        return true;
    }
}