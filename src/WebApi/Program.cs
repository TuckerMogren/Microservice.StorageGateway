using Microservice.StorageGateway.WebApi.Configuration;
using Microservice.StorageGateway.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly, optional: true)
    //.ConfigureVault()
    .AddEnvironmentVariables();


builder.Services.AddOpenApi();
builder.Services.AddSwagger();

builder.Configuration.BindApplicationSettings(builder.Services);
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


