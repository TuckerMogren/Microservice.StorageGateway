using Microservice.StorageGateway.Application.Interfaces.Repositories;
using Microservice.StorageGateway.Infrastructure;
using Microservice.StorageGateway.Persistence.GoogleDrive;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureDependencies
{
    public static void RegisterDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IGoogleDriveRepository, GoogleDriveRepository>();
    }
}
