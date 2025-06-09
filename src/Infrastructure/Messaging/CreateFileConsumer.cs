using MassTransit;
using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Contracts.Messages.Commands;
using Microservice.StorageGateway.Contracts.Messages.Responses;
using Microsoft.Extensions.Logging;

namespace Microservice.StorageGateway.Infrastructure.Messaging
{
    public class CreateFileConsumer(IGoogleDriveRepository repository, ILogger<CreateFileConsumer> logger) : IConsumer<CreateFile>
    {
        private readonly IGoogleDriveRepository _repository = repository;
        private readonly ILogger<CreateFileConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<CreateFile> context)
        {
            using var stream = new MemoryStream(context.Message.FileBytes);

            var fileId = await _repository.UploadFileAsync(
                stream,
                context.Message.FileName,
                context.Message.MimeType,
                context.Message.ParentFolderId
            );

            await context.RespondAsync<FileCreated>(new
            {
                context.Message.CorrelationId,
                FileId = fileId
            });
        }
    }
}