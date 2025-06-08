using Microservice.StorageGateway.Contracts.Enums;

namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IServiceBusSettings
{
    public MessageBrokerName MessageBrokerName  { get; }
    public string? ConnectionString { get; }
    public string? Username  { get; }
    public string? Password { get; }
}
