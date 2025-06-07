using Serilog.Context;

namespace Microservice.StorageGateway.WebApi.Configuration
{
    public class CorrelationIdMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private const string HeaderKey = "x-correlation-id";

        public async Task Invoke(HttpContext context)
        {
            var rawHeader = context.Request.Headers[HeaderKey].FirstOrDefault();
            var correlationId = !string.IsNullOrWhiteSpace(rawHeader) ? rawHeader : Ulid.NewUlid().ToString();

            context.Items["CorrelationId"] = correlationId;
            context.Response.Headers[HeaderKey] = correlationId;

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next(context);
            }
        }
    }
}