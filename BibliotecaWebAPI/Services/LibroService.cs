using BibliotecaWebAPI.Exceptions;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using BibliotecaWebAPI.Services.Interfaces;

namespace BibliotecaWebAPI.Services
{
    public class LibroService : ILibroService
    {
        private readonly IDAO<Libro> _libroDAO;

        public LibroService(IDAO<Libro> libroDAO)
        {
            _libroDAO = libroDAO;
        }

        public Libro CreateBook(Libro libro)
        {
            return _libroDAO.Create(libro);
        }

        public Libro GetBook(int id)
        {
            Libro libro = _libroDAO.Get(id);
            if (libro == null)
            {
                throw new EntityNotFoundException($"El libro con id {id} no ha sido encontrado");
            }
            return libro;
        }

        public List<Libro> GetAllBooks()
        {
            return _libroDAO.GetAll();
        }

        public List<Libro> GetAllBooksByIds(List<int> ids)
        {
            var libros = _libroDAO.GetAllByIds(ids);
            if (libros == null || !libros.Any())
            {
                throw new EntityNotFoundException("No se encontraron libros con los ids proporcionados");
            }
            return libros;
        }

        public Libro UpdateBook(Libro libro)
        {
            if (_libroDAO.Get(libro.Id) == null)
            {
                throw new EntityNotFoundException($"El libro con id {libro.Id} no ha sido encontrado");
            }
            return _libroDAO.Update(libro);
        }

        public void DeleteBook(int id)
        {
            Libro libro = _libroDAO.Get(id);
            if (libro == null)
            {
                throw new EntityNotFoundException($"El libro con id {id} no ha sido encontrado");
            }
            if (!libro.Available)
            {
                throw new InvalidOperationException("El libro no está disponible y no puede ser eliminado");
            }
            _libroDAO.Delete(id);
        }
    }
}
