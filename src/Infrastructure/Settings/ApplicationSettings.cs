using Microservice.StorageGateway.Contracts.Settings.Interfaces;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class ApplicationSettings : IApplicationSettings
{
    public IStorageGatewayVaultSettings storageGatewayVaultSettings { get; set; } = new StorageGatewayVaultSettings();
}
