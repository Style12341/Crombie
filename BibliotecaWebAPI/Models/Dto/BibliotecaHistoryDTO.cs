using BibliotecaWebAPI.Persistance;

namespace BibliotecaWebAPI.Models.Dto
{
    public class BibliotecaHistoryDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public int BookId { get; set; }

        public DateTime Fecha { get; set; }

        public BibliotecaHistoryDTO(int userId, string userName, string action, int bookId)
        {
            UserId = userId;
            UserName = userName;
            Action = action;
            BookId = bookId;
        }

        public BibliotecaHistoryDTO() { }

        public static BibliotecaHistoryDTO FromHistory(BibliotecaHistory history)
        {
            return new BibliotecaHistoryDTO(history.Usuario.Id, history.Usuario.Nombre, history.Action, history.Libro.Id);
        }
    }
}