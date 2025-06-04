using Microservice.StorageGateway.Contracts.Settings.Interfaces;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class StorageGatewayVaultSettings : IStorageGatewayVaultSettings
{
    public string DbPassword { get; set; } = default!;
    public string ApiKey { get; set; } = default!;
}