using System;

namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IApplicationSettings
{
    IStorageGatewayVaultSettings storageGatewayVaultSettings{ get; }
}
