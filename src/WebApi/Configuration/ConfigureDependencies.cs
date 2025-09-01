using Microservice.StorageGateway.Application.Commands;
using Microservice.StorageGateway.Application.Commands.CreateFile;
using Microservice.StorageGateway.Application.Commands.DeleteFile;
using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Infrastructure.Messaging;
using Microservice.StorageGateway.Persistence.GoogleDrive;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureDependencies
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGoogleDriveRepository, GoogleDriveRepository>();
        services.AddScoped<ICreateFileCommandHandler, CreateFileCommandHandler>();
        services.AddScoped<IDeleteFileCommandHanlder, DeleteFileCommandHanlder>();
    }

    public static void RegisterMassTransitDispatchers(this IServiceCollection services)
    {
        services.AddScoped<IDeleteFileCommandDispatcher, MassTransitFileCommandDispatcher>();
        services.AddScoped<ICreateFileCommandDispatcher, MassTransitFileCommandDispatcher>();
    }
}
