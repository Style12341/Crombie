using System.Net;
using System.Text.Json;
using BibliotecaWebAPI.Exceptions;
using BibliotecaWebAPI.Logging;

namespace BibliotecaWebAPI.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly FileLogger _logger;
        public ErrorLoggingMiddleware(RequestDelegate next, FileLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                EntityNotFoundException => (int)HttpStatusCode.NotFound,
                InvalidOperationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };
            if (context.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                _logger.LogError($"Error procesando la peticion: {context.Request.Method} {context.Request.Path}", exception);
            }

            var result = JsonSerializer.Serialize(new { error = exception.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
