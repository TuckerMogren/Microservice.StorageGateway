using Microservice.StorageGateway.WebApi.Configuration;
using Microservice.StorageGateway.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly, optional: true)
    //.ConfigureVault()
    .AddEnvironmentVariables();

var appsettings = builder.Configuration.BindApplicationSettings(builder.Services);
builder.Services.RegisterMassTransitDispatchers();
builder.Services.ConfigureMassTransitMessaging(appsettings.ServiceBusSettings);
builder.Services.RegisterGoogleDrive(appsettings.GoogleDriveSettings);
builder.Services.RegisterRepositories();
builder.Services.AddOpenApi();
builder.Services.AddSwagger();

builder.ConfigureSerilogLogging();
var app = builder.Build();
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseRouting();

if(!app.Environment.IsProduction()) 
{
    app.MapOpenApi();
    app.UseSwaggerWithUI();
}

app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();


