using Google.Apis.Auth.OAuth2;
using Microservice.StorageGateway.Contracts.Settings.Interfaces;
using Newtonsoft.Json;

namespace Microservice.StorageGateway.WebApi.Configuration;
public static class ConfigureGoogleDrive
{
    public static IServiceCollection RegisterGoogleDrive(this IServiceCollection services, IGoogleDriveSettings settings)
    {

        services.AddScoped(provider =>
        {
            return GoogleCredential
                .FromJson(JsonConvert.SerializeObject(settings.CredentialFile, Formatting.Indented))
                .CreateScoped(settings.Scopes);
        });

        return services;
    }
}