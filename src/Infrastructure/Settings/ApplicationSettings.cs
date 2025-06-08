using Microservice.StorageGateway.Contracts.Settings.Interfaces;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class ApplicationSettings : IApplicationSettings
{
    public IStorageGatewayVaultSettings StorageGatewayVaultSettings { get; set; } = new StorageGatewayVaultSettings();

    public IServiceBusSettings ServiceBusSettings { get; set; } = new ServiceBusSettings();

    public IGoogleDriveSettings GoogleDriveSettings { get; set; } = new GoogleDriveSettings();
}
