using BibliotecaWebAPI.Models;

namespace BibliotecaWebAPI.Services.Interfaces
{
    public interface ILibroService
    {
        Libro CreateBook(Libro libro);
        void DeleteBook(int id);
        List<Libro> GetAllBooks();
        List<Libro> GetAllBooksByIds(List<int> ids);
        Libro GetBook(int id);
        Libro UpdateBook(Libro libro);
    }
}