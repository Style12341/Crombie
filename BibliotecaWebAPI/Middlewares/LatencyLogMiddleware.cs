using BibliotecaWebAPI.Logging;
using System.Diagnostics;

namespace BibliotecaWebAPI.Middlewares
{
    public class LatencyLogMiddleware
    {
        private readonly RequestDelegate _next; //Continua con el siguiente middleware
        private readonly ILogger _logger;
        private readonly FileLogger _fileLogger;
        public LatencyLogMiddleware(RequestDelegate next, ILoggerFactory
        loggerFactory, FileLogger fileLogger)
        {
            _next = next;
            _fileLogger = fileLogger;
            _logger = loggerFactory.CreateLogger(typeof(LatencyLogMiddleware));
        }
        public async Task Invoke(HttpContext context)
        {
            //Este id es para simular un ID que viene del FrontEnd/Container
            //Con el cual mantenemos "trace" de toda la acción del usuario
            //Antes de la request
            Guid traceId = Guid.NewGuid();
            _logger.LogDebug($"Request {traceId} iniciada");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start(); //Indica cuánto toma procesar la solicitud
            await _next(context);
            //Despues de la request
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime =
            String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            _logger.LogDebug($"La request {traceId} ha llevado {elapsedTime}");
            _fileLogger.LogDebug($"La request {traceId} ha llevado {elapsedTime}");
        }
    }
}
