using PtProgramTrackerApi.Domain.Interfaces;

namespace PtProgramTrackerApi.Middleware
{
    public class RequestContextMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var clientIdHeader = context.Request.Headers["Client-Id"];

            if (int.TryParse(clientIdHeader, out var clientId))
            {
                var requestContext = context.RequestServices.GetRequiredService<IRequestContext>();
                requestContext.ClientId = clientId;
            }

            await _next(context);
        }
    }
}
