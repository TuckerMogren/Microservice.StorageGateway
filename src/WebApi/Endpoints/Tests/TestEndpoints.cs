namespace Microservice.StorageGateway.WebApi.Endpoints.Tests;

public static class TestEndpoints
{
    public static IEndpointRouteBuilder MapTestEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/test", (ILogger logger) =>
        {
            logger.LogInformation("Test endpoint hit");
            return Results.Ok("Hello World!");
        })
        .WithName("Test");

        return endpoints;
    }
}