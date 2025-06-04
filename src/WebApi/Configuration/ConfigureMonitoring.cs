using Serilog;
using Serilog.Events;

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
            .WriteTo.Console()
            .WriteTo.File("Logs/app.log", rollingInterval: RollingInterval.Day)
            .WriteTo.ApplicationInsights(
                configuration["ApplicationInsights:ConnectionString"] 
                    ?? configuration["ApplicationInsights:InstrumentationKey"],
                TelemetryConverter.Traces,
                restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}