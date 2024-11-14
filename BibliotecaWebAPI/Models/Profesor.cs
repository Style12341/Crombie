using BibliotecaApp;

namespace BibliotecaWebAPI.Models
{
    public class Profesor : Usuario
    {
        public override string UserType { get; } = "Profesor";
        public Profesor(int id, string nombre, List<Libro> librosPrestados) : base(id, nombre, librosPrestados)
        {
        }
        public Profesor(int id, string nombre) : base(id, nombre)
        {
        }
        public override bool LendBook(Libro l)
        {
            if (LibrosPrestados.Count >= 5)
            {
                Console.WriteLine("El profesor no puede tener más de 5 libros prestados");
                return false;
            }
            return base.LendBook(l);
        }
    }
}
