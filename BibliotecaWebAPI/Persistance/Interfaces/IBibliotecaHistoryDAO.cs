using BibliotecaWebAPI.Models.Dto;

namespace BibliotecaWebAPI.Persistance.Interfaces
{
    public interface IBibliotecaHistoryDAO : IDAO<BibliotecaHistoryDTO>
    {
        public List<BibliotecaHistoryDTO> GetByBook(int id);
        public List<BibliotecaHistoryDTO> GetByUser(int id);
    }
}