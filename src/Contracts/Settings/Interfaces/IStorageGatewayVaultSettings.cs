namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IStorageGatewayVaultSettings
{
    string DbPassword { get; }
    string ApiKey { get; }
}