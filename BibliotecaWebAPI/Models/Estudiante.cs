using BibliotecaApp;

namespace BibliotecaWebAPI.Models
{
    public class Estudiante : Usuario
    {
        public override string UserType { get; } = "Estudiante";

        public Estudiante() : base() { }
        public Estudiante(int id, string nombre, List<Libro> librosPrestados) : base(id, nombre, librosPrestados)
        {
        }
        public Estudiante(int id, string nombre) : base(id, nombre)
        {
        }

        override public bool LendBook(Libro book)
        {
            if (LibrosPrestados.Count >= 3)
            {
                Console.WriteLine("El estudiante no puede tener más de 3 libros prestados");
                return false;
            }
            return base.LendBook(book);
        }

    }
}
