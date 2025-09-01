using MassTransit;
using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Contracts.Messages.Commands;
using Microservice.StorageGateway.Contracts.Messages.Responses;
using Microsoft.Extensions.Logging;

namespace Microservice.StorageGateway.Infrastructure.Messaging
{
    public class DeleteFileConsumer(IGoogleDriveRepository repository, ILogger<DeleteFileConsumer> logger) : IConsumer<DeleteFile>
    {

        public async Task Consume(ConsumeContext<DeleteFile> context)
        {
            logger.LogInformation($"Starting to consume: {nameof(DeleteFileConsumer)}");
            await repository.DeleteFileAsync(
                context.Message.FileId
            );
            logger.LogInformation("File with Id: {FileId} was Deleted. Responding with FileDeleted Event", context.Message.FileId);
            await context.RespondAsync<FileDeleted>(new
            {
                FileId = context.Message.FileId
            });
        }
    }
}