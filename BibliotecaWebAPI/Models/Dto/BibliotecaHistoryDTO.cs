using BibliotecaWebAPI.Persistance;

namespace BibliotecaWebAPI.Models.Dto
{
    public class BibliotecaHistoryDTO(int userId, string userName, string action, int bookId)
    {
        public int UserId { get; set; } = userId;
        public string UserName { get; set; } = userName;
        public string Action { get; set; } = action;
        public int BookId { get; set; } = bookId;

        public static BibliotecaHistoryDTO FromHistory(BibliotecaHistory history)
        {
            return new BibliotecaHistoryDTO(history.Usuario.Id, history.Usuario.Nombre, history.Action, history.Libro.Id);
        }
    }
}
