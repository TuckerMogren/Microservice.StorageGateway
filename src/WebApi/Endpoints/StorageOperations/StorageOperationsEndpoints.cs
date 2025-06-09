using Microservice.StorageGateway.Application.Commands.CreateFile;
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
        endpoints.MapPost("/CreateFileAsync", async (
            HttpContext context,
            [FromServices] ILoggerFactory loggerFactory,
            [FromServices] ICreateFileCommandHandler handler,
            IFormFile file,
            [FromQuery] string? folderId) =>
        {
            var logger = loggerFactory.CreateLogger(nameof(StorageOperationsEndpoints));
            logger.LogInformation($"{nameof(MapCreateFileEndpoint)} endpoint hit");

            try
            {
                if (file == null || file.Length == 0)
                    return Results.BadRequest("A file must be provided.");

                logger.LogInformation("File is Ok: FileName: {Name}, FileLength: {Length}", file.FileName ,file.Length);
                var fileId = await handler.HandleAsync(new CreateFileCommandModel
                {
                    FileStream = file.OpenReadStream(),
                    FileName = file.FileName,
                    MimeType = file.ContentType,
                    ParentFolderId = folderId
                });

                logger.LogInformation("{FileId} was created!", fileId);
                return Results.Ok(fileId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to add file.");
                return Results.Problem(
                    detail: "An unexpected error occurred while creating the file.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        })
        .DisableAntiforgery()
        .Accepts<IFormFile>("multipart/form-data")
        .Produces<string>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName("CreateFile");

        return endpoints;
    }

}
