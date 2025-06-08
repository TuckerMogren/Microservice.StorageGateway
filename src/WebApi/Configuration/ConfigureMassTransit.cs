using System.Reflection;
using MassTransit;
using Microservice.StorageGateway.Contracts.Enums;
using Microservice.StorageGateway.Contracts.Settings.Interfaces;
using Microservice.StorageGateway.Infrastructure;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureMassTransit
{
    public static void ConfigureMassTransitMessaging(this IServiceCollection services, IServiceBusSettings settings)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(settings.ConnectionString, nameof(settings.ConnectionString));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(settings.Password, nameof(settings.Password));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(settings.Username, nameof(settings.Username));

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(x => x.GetName().Name == "Microservice.StorageGateway.Infrastructure")
            .ToArray();

        services.AddMassTransit(x =>
        {
            x.AddConsumers(assemblies);
            switch (settings.MessageBrokerName)
            {
                case MessageBrokerName.RabbitMq:
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(settings.ConnectionString, "/", h =>
                        {
                            h.Username(settings.Username!);
                            h.Password(settings.Password!);
                        });

                        cfg.ConfigureEndpoints(context);
                    });
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported MessageBroker: {settings.MessageBrokerName}");
            }
        });
    }
}