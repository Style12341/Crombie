namespace BibliotecaWebAPI.Logging
{
    public class FileLogger
    {
        private readonly string _filePath;
        private ILogger _logger;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void SetLogger(ILogger logger)
        {
            _logger = logger;
        }
        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
            var msg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - DEBUG: {message}\n";
            WriteToFile(msg);
        }
        public void LogError(string message, Exception ex)
        {
            _logger.LogError(message, ex);
            var msg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - ERROR: {message}\n" + $"\tException: {ex.Message}\n\t" + $"Stack Trace: {ex.StackTrace}\n";
            WriteToFile(msg);
        }
        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
            var msg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - INFO: {message}\n";
            WriteToFile(msg);
        }
        public void WriteToFile(string message)
        {
            lock (this)
            {
                File.AppendAllText(_filePath, message);
            }
        }
    }
}
