
using Microservice.StorageGateway.WebApi.Configuration;
using Microservice.StorageGateway.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    //.ConfigureVault()
    .Build();

builder.Services.AddOpenApi();
builder.Services.AddSwagger();

builder.Configuration.BindApplicationSettings(builder.Services);
builder.ConfigureSerilogLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerWithUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();


