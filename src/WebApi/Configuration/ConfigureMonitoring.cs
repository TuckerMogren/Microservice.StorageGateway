using Serilog;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class SerilogLoggingExtensions
{
    public static void ConfigureSerilogLogging(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var environment = builder.Environment;

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Environment", environment.EnvironmentName)
            .Enrich.WithCorrelationId()
            .CreateLogger();

        builder.Host.UseSerilog();
    
    }
}