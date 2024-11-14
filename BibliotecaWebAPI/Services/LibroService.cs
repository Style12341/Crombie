using BibliotecaApp;
using BibliotecaWebAPI.Persistance;

namespace BibliotecaWebAPI.Services
{
    public class LibroService
    {
        private readonly IDAO<Libro> _libroDAO = new LibroDAOExcel();
        public Libro CreateBook(Libro libro)
        {
            return _libroDAO.Create(libro);
        }
        public Libro GetBook(int id)
        {
            return _libroDAO.Get(id);
        }
        public List<Libro> GetAllBooks()
        {
            return _libroDAO.GetAll();
        }
        public List<Libro> GetAllBooksByIds(List<int> ids)
        {
            return _libroDAO.GetAllByIds(ids);
        }
        public Libro UpdateBook(Libro libro)
        {
            return _libroDAO.Update(libro);
        }
        public void DeleteBook(int id)
        {
            Libro libro = _libroDAO.Get(id);
            if (libro == null)
            {
                throw new Exception("The book does not exist");
            }
            if(!libro.Available)
            {
                throw new Exception("The book is not available it can't be deleted");
            }
            _libroDAO.Delete(id);
        }
    }
}
