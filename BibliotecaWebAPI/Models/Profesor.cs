using BibliotecaApp;

namespace BibliotecaWebAPI.Models
{
    public class Profesor : Usuario
    {
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
