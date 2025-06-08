using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using Google.Apis.Drive.v3;
using Microservice.StorageGateway.Contracts.Settings.Interfaces;

public static class ConfigureGoogleDrive
{
    public static IServiceCollection RegisterGoogleDrive(this IServiceCollection services, IGoogleDriveSettings settings)
    {

        services.AddScoped<GoogleCredential>(provider =>
        {
            return GoogleCredential
                .FromFile(settings.CredentialFilePath)
                .CreateScoped(settings.Scopes);
        });

        return services;
    }
}