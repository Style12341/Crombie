using BibliotecaApp;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance;
using System.Net;

namespace BibliotecaWebAPI.Services
{
    public class BibliotecaService
    {
        private static LibroService _libroService = new LibroService();
        private static UsuarioService _usuarioService = new UsuarioService();

        public bool LendBook(BibliotecaOperationDTO ids)
        {
            Usuario user = _usuarioService.GetUser(ids.user_id);
            Libro book = _libroService.GetBook(ids.book_id);
            if (!user.LendBook(book))
                return false;
            _usuarioService.UpdateUser(user);
            _libroService.UpdateBook(book);
            return true;
        }
        public bool ReturnBook(BibliotecaOperationDTO ids)
        {
            Usuario user = _usuarioService.GetUser(ids.user_id);
            Libro book = _libroService.GetBook(ids.book_id);
            if (!user.ReturnBook(book))
                return false;
            _usuarioService.UpdateUser(user);
            _libroService.UpdateBook(book);
            return true;
        }
    }
}
