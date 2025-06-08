// Infrastructure Layer
// File: Infrastructure/Messaging/MassTransitFileCommandDispatcher.cs

using MassTransit;
using Microservice.StorageGateway.Application.Commands.CreateFile;
using Microservice.StorageGateway.Contracts.Messages.Commands;
using Microservice.StorageGateway.Contracts.Messages.Responses;

namespace Microservice.StorageGateway.Infrastructure.Messaging;

public class MassTransitFileCommandDispatcher(IRequestClient<CreateFile> client) : IFileCommandDispatcher
{
    private readonly IRequestClient<CreateFile> _client = client;

    public async Task<string> SendCreateFileAsync(CreateFileCommandModel model, CancellationToken cancellationToken = default)
    {
        using var ms = new MemoryStream();
        await model.FileStream.CopyToAsync(ms, cancellationToken);

        var response = await _client.GetResponse<FileCreated>(new
        {
            CorrelationId = Guid.NewGuid(),
            FileName = model.FileName,
            MimeType = model.MimeType,
            FileBytes = ms.ToArray(),
            ParentFolderId = model.ParentFolderId
        });

        return response.Message.FileId;
    }
}