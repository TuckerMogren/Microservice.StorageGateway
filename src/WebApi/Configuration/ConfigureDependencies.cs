using Microservice.StorageGateway.Application.Commands.CreateFile;
using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Infrastructure;
using Microservice.StorageGateway.Infrastructure.Messaging;
using Microservice.StorageGateway.Persistence.GoogleDrive;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureDependencies
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGoogleDriveRepository, GoogleDriveRepository>();
        services.AddScoped<IFileCommandDispatcher, MassTransitFileCommandDispatcher>();
        services.AddScoped<ICreateFileCommandHandler, CreateFileCommandHandler>();
    }

    public static void RegisterMassTransitDispatchers(this IServiceCollection services)
    {
        services.AddScoped<IFileCommandDispatcher, MassTransitFileCommandDispatcher>();
    }
}
