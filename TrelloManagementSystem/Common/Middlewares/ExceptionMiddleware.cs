using System.Net;
using System.Text.Json;
using TrelloManagementSystem.Common.ErrorHandling;
using TrelloManagementSystem.Common.Helper.ExtensionMethod;

namespace TrelloManagementSystem.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                AddSerilog.AddSerilogLogger(httpContext.RequestServices.GetRequiredService<ILoggingBuilder>(), httpContext.RequestServices.GetRequiredService<IConfiguration>(), httpContext.RequestServices.GetRequiredService<WebApplicationBuilder>());

                httpContext.Response.StatusCode = ex switch
                {
                    InvalidOperationException or ArgumentException => (int)HttpStatusCode.BadRequest, // 400
                    KeyNotFoundException => (int)HttpStatusCode.NotFound, // 404
                    _ => (int)HttpStatusCode.InternalServerError // 500
                };

                httpContext.Response.ContentType = "application/json";

                var response = _env.IsDevelopment()
                    ? new ApiExceptionResponse(httpContext.Response.StatusCode, $"{ex.GetType().Name}: {ex.Message}", ex.StackTrace)
                    : new ApiExceptionResponse(httpContext.Response.StatusCode, "An unexpected error occurred. Please try again later.");

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}

