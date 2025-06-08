using Microsoft.AspNetCore.Mvc;

namespace Microservice.StorageGateway.WebApi.Endpoints.StorageOperations;

public static class StorageOperationsEndpoints
{
    public static IEndpointRouteBuilder MapFileCrudOperations(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapCreateFileEndpoint();
        return endpoints;
    }

    private static IEndpointRouteBuilder MapCreateFileEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/CreateFileAsync", ([FromServices] ILoggerFactory loggerFactory) =>
        {
            var logger = loggerFactory.CreateLogger(nameof(StorageOperationsEndpoints));
            logger.LogInformation("Test endpoint hit");
            return Results.Ok("Hello World!");
        });

        return endpoints;
    }

}
