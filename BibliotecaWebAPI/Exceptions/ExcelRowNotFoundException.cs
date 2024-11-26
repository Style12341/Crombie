namespace BibliotecaWebAPI.Exceptions
{
    public class ExcelRowNotFoundException : Exception
    {
        public ExcelRowNotFoundException()
        {
        }
        public ExcelRowNotFoundException(string message) : base(message)
        {
        }
        public ExcelRowNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
