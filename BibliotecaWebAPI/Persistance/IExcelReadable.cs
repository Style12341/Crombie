namespace BibliotecaWebAPI.Persistance
{
    public interface IExcelReadable<T> where T : class
    {
        public List<T> GetData(string filePath);
        public void InsertData(string filePath, List<T> data);
        public void UpdateData(string filePath, T data);
    }
}
