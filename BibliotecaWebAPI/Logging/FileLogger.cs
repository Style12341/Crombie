namespace BibliotecaWebAPI.Logging
{
    public class FileLogger
    {
        private readonly string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void LogError(string message, Exception ex)
        {
            var msg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - ERROR: {message}\n" + $"\tException: {ex.Message}\n\t" + $"Stack Trace: {ex.StackTrace}\n";
            WriteToFile(msg);
        }
        public void LogInfo(string message)
        {
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
