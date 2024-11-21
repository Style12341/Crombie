using BibliotecaWebAPI.Models;

namespace BibliotecaWebAPI.Services.Interfaces
{
    public interface IBibliotecaService
    {
        List<BibliotecaHistory> GetBookHistory(int bookId);
        List<BibliotecaHistory> GetHistory();
        List<BibliotecaHistory> GetUserHistory(int userId);
        bool LendBook(BibliotecaOperationDTO ids);
        bool ReturnBook(BibliotecaOperationDTO ids);
    }
}