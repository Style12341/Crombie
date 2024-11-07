using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaApp
{
    public class Biblioteca
    {

        private List<Usuario> Usuarios = new List<Usuario>();
        private List<Libro> Libros = new List<Libro>();

        public bool AddBook(string titulo, string autor, string isbn)
        {
            //Check if isbn is already in the list
            if (GetBook(isbn) != null)
            {
                Console.WriteLine("ISBN repetido");
                return false;
            }
            Libro libro = new Libro(titulo, autor, isbn);
            Libros.Add(libro);
            return true;
        }
        public Libro GetBook(string isbn)
        {
            foreach (Libro l in Libros)
            {
                if (l.Isbn == isbn)
                {
                    return l;
                }
            }
            return null;
        }
        public Usuario GetUser(int id)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.Identifier == id)
                {
                    return u;
                }
            }
            return null;
        }
        internal bool RegisterUser(int id, string nombre)
        {

            if (GetUser(id) != null)
            {
                Console.WriteLine("ID Usuario repetido");
                return false;
            }
            Usuario user = new Usuario(id, nombre);
            Usuarios.Add(user);
            return true;
        }

        internal bool LendBook(int userId, string isbn)
        {
            // Check that user exists
            Usuario u = GetUser(userId);
            if (u == null)
            {
                Console.WriteLine("Usuario no encontrado");
                return false;
            }
            // Check that book exists
            Libro l = GetBook(isbn);
            if (l == null)
            {
                Console.WriteLine("Libro no encontrado");
                return false;
            }
            // Check book is available
            if (l.Available == false)
            {
                Console.WriteLine("Libro no disponible");
                return false;
            }
            u.ReceiveBook(l);
            l.Available = false;
            return true;
        }

        internal bool ReturnBook(int userId, string isbn)
        {
            // Check that user exists
            Usuario u = GetUser(userId);
            if (u == null)
            {
                Console.WriteLine("Usuario no encontrado");
                return false;
            }
            // Check that book exists
            Libro l = GetBook(isbn);
            if (l == null)
            {
                Console.WriteLine("Libro no encontrado");
                return false;
            }
            if (l.Available)
            {
                Console.WriteLine("Libro no prestado");
            }
            return u.ReturnBook(l);
        }

        internal string GetBooksState()
        {
            StringBuilder state = new StringBuilder();
            foreach (var book in Libros)
            {
                state.Append(book.GetState());
                state.Append('\n');
            }
            return state.ToString();
        }

        internal bool GetLentBooksOfUser(int userId)
        {
            Usuario u = GetUser(userId);
            if (u == null)
            {
                Console.WriteLine("Usuario no encontrado");
                return false;
            }
            List<Libro> librosPrestados = u.GetLentBooks();
            foreach (var libro in librosPrestados)
            {
                Console.WriteLine(libro.GetState());
            }
            return true;
        }
    }
}
