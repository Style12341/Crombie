using BibliotecaApp;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Persistance.Interfaces;
using BibliotecaWebAPI.Services.Interfaces;
using System.Net;

namespace BibliotecaWebAPI.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly ILibroService _libroService;
        private readonly IUsuarioService _usuarioService;
        private readonly IBibliotecaHistoryDAO _historyDAO;
        public BibliotecaService(ILibroService libroService, IUsuarioService usuarioService, IBibliotecaHistoryDAO historyDao)
        {
            _libroService = libroService;
            _usuarioService = usuarioService;
            _historyDAO = historyDao;
        }
        public bool LendBook(BibliotecaOperationDTO ids)
        {
            Usuario user = _usuarioService.GetUser(ids.user_id);
            Libro book = _libroService.GetBook(ids.book_id);
            if (!user.LendBook(book))
                return false;
            var historyDTO = new BibliotecaHistoryDTO
            (
                user.Id,
                user.Nombre,
                "Prestar",
                book.Id
            );
            _historyDAO.Create(historyDTO);
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
            var historyDTO = new BibliotecaHistoryDTO
            (
                user.Id,
                user.Nombre,
                "Devolver",
                book.Id
            );
            _historyDAO.Create(historyDTO);
            _usuarioService.UpdateUser(user);
            _libroService.UpdateBook(book);
            return true;
        }
        public List<BibliotecaHistory> GetHistory()
        {
            var historyDTO = _historyDAO.GetAll();
            List<BibliotecaHistory> history = ParseDTOs(historyDTO);
            return history;
        }
        public List<BibliotecaHistory> GetUserHistory(int userId)
        {
            var historyDTO = _historyDAO.GetByUser(userId);
            List<BibliotecaHistory> history = ParseDTOs(historyDTO);
            return history;
        }
        public List<BibliotecaHistory> GetBookHistory(int bookId)
        {
            var historyDTO = _historyDAO.GetByBook(bookId);
            List<BibliotecaHistory> history = ParseDTOs(historyDTO);
            return history;
        }

        private List<BibliotecaHistory> ParseDTOs(List<BibliotecaHistoryDTO> historyDTO)
        {
            List<BibliotecaHistory> history = new();
            Dictionary<int, Usuario> users = new();
            Dictionary<int, Libro> books = new();
            foreach (var historyItem in historyDTO)
            {
                if (!users.ContainsKey(historyItem.UserId))
                {
                    users.Add(historyItem.UserId, _usuarioService.GetUser(historyItem.UserId));
                }
                if (!books.ContainsKey(historyItem.BookId))
                {
                    books.Add(historyItem.BookId, _libroService.GetBook(historyItem.BookId));
                }
                history.Add(new BibliotecaHistory
                {
                    Usuario = users[historyItem.UserId],
                    Libro = books[historyItem.BookId],
                    Action = historyItem.Action
                });
            }
            return history;
        }
    }
}
