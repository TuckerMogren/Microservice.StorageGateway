
using Microservice.StorageGateway.WebApi.Configuration;
using Microservice.StorageGateway.WebApi.Endpoints;
using CorrelationId;
using CorrelationId.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly, optional: true)
    //.ConfigureVault()
    .AddEnvironmentVariables();

builder.Services.AddDefaultCorrelationId(options =>
{
    options.RequestHeader = "x-correlation-id";
    options.IncludeInResponse = true;
});
builder.Services.AddOpenApi();
builder.Services.AddSwagger();

builder.Configuration.BindApplicationSettings(builder.Services);
builder.ConfigureSerilogLogging();
var app = builder.Build();
app.UseCorrelationId();
app.UseRouting();

if(!app.Environment.IsProduction()) 
{
    app.MapOpenApi();
    app.UseSwaggerWithUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<Microservice.StorageGateway.WebApi.Configuration.CorrelationIdMiddleware>();
app.MapEndpoints();

app.Run();


