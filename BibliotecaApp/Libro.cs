using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        
        public bool Available { get; set; } = true;
        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
        }
        public string GetState()
        {
            string av = Available ? "SI" : "NO";
            return $"Titulo: {Titulo}, Autor: {Autor}, ISBN: {Isbn}, Disponible: {av}";
        }
    }
}
