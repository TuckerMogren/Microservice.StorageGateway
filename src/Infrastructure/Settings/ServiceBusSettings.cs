using Microservice.StorageGateway.Contracts.Enums;
using Microservice.StorageGateway.Contracts.Settings.Interfaces;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class ServiceBusSettings : IServiceBusSettings
{
    public MessageBrokerName MessageBrokerName { get; set; }
    public string? ConnectionString { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
