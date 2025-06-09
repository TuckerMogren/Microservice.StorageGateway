using Microservice.StorageGateway.Contracts.Settings.Interfaces;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class GoogleDriveSettings : IGoogleDriveSettings
{
    public string CredentialFile { get; init; } = string.Empty;

    public IEnumerable<string> Scopes { get; init; } = [];
}
