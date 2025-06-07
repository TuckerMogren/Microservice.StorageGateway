using Microsoft.AspNetCore.Mvc;

namespace Microservice.StorageGateway.WebApi.Endpoints.Tests;

public static class TestEndpoints
{
    public static IEndpointRouteBuilder MapTestEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/test", ([FromServices] ILoggerFactory loggerFactory) =>
        {
            var logger = loggerFactory.CreateLogger(nameof(TestEndpoints));
            logger.LogInformation("Test endpoint hit");
            return Results.Ok("Hello World!");
        })
        .WithName("Test");

        return endpoints;
    }
}