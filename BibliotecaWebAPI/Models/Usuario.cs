using BibliotecaWebAPI.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaWebAPI.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public abstract string UserType { get; }
        public List<Libro> LibrosPrestados { get; set; } = [];

        public Usuario() { }
        public Usuario(int id, string nombre, List<Libro> librosPrestados) : this(id, nombre)
        {
            LibrosPrestados = librosPrestados;
        }

        public Usuario(int identifier, string nombre)
        {
            Id = identifier;
            Nombre = nombre;
        }

        virtual public bool LendBook(Libro l)
        {
            if (!l.Available)
            {
                Console.WriteLine("El libro no se encuentra disponible");
                return false;
            }
            LibrosPrestados.Add(l);
            l.Prestante = this;
            return true;
        }

        internal bool ReturnBook(Libro l)
        {
            //Verify that the book is in the list
            //Try to get book
            Libro lentBook = LibrosPrestados.Where(x => x.Id == l.Id).First();
            if (lentBook.Id == l.Id)
            {
                LibrosPrestados = LibrosPrestados.Where(x => x.Id != l.Id).ToList();
                l.Prestante = null;
                return true;
            }
            Console.WriteLine("El usuario ingresado no posee el libro");
            return false;
        }

        internal List<Libro> GetLentBooks()
        {
            return LibrosPrestados;
        }
    }
}
