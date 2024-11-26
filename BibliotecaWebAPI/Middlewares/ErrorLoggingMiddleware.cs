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
                _logger.LogError($"Error procesando la peticion: {context.Request.Method} {context.Request.Path}", ex);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Ha ocurrido un error en el servidor");
            }
        }
    }
}
