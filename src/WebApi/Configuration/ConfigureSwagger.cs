using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class ConfigureSwagger
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Storage Gateway API",
                Version = "v1",
                Description = "API for managing storage operations in the microservice architecture.",
                Contact = new OpenApiContact
                {
                    Name = "Support Team",
                    Email = "mogrent@hotmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                },
                TermsOfService = new Uri("https://www.termsfeed.com/blog/sample-terms-of-service-template/")
            });

            // Optional: include XML comments
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }
    
    public static void UseSwaggerWithUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Storage Gateway API v1");
            c.RoutePrefix = string.Empty;
        });
    }
}