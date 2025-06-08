
using Microservice.StorageGateway.WebApi.Endpoints.StorageOperations;
using Microservice.StorageGateway.WebApi.Endpoints.Tests;

namespace Microservice.StorageGateway.WebApi.Endpoints;

public static class EndpointHandler
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        // Register all endpoint groups here
        app.MapTestEndpoints();
        app.MapFileCrudOperations();

        return app;
    }
}