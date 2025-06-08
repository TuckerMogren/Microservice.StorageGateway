using System;

namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IApplicationSettings
{
    IStorageGatewayVaultSettings StorageGatewayVaultSettings { get; }
    IServiceBusSettings ServiceBusSettings{ get; }
}
