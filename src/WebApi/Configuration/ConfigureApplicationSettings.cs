using Microservice.StorageGateway.Contracts.Settings.Interfaces;
using Microservice.StorageGateway.Infrastructure.Settings;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureApplicationSettings
{
    public static IApplicationSettings BindApplicationSettings(this IConfiguration config, IServiceCollection services)
    {
        // Bind config immediately and register as IApplicationSettings
        var settings = new ApplicationSettings();
        config.Bind(settings);
        services.AddSingleton<IApplicationSettings>(settings);

        

        return settings;
    }
}