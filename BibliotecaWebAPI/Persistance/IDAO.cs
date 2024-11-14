namespace BibliotecaWebAPI.Persistance
{
    public interface IDAO<T> where T : class
    {
        public T Create(T obj);
        public T Get(int id);

        public List<T> GetAllByIds(List<int> ids);
        public List<T> GetAll();
        public T Update(T obj);
        public void Delete(int id);

    }
}
