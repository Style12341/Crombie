using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp
{
    public class Usuario
    {
        public int Identifier { get; set; }
        public string Nombre { get; set; }

        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();
        public Usuario(int identifier, string nombre)
        {
            Identifier = identifier;
            Nombre = nombre;
        }

        internal void ReceiveBook(Libro l)
        {
            LibrosPrestados.Add(l);
        }

        internal bool ReturnBook(Libro l)
        {
            //Verify that the book is in the list
            if (LibrosPrestados.Contains(l))
            {
                LibrosPrestados.Remove(l);
                l.Available = true;
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
