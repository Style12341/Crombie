using BibliotecaWebAPI.Persistance;

namespace BibliotecaWebAPI.Models
{
    public class BibliotecaHistory
    {
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }
        public string Action { get; set; }
    }
}
