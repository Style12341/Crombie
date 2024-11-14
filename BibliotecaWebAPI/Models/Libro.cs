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
        public string Id { get; set; }
        
        public bool Available { get; set; } = true;
        public Libro(string titulo, string autor, string id)
        {
            Titulo = titulo;
            Autor = autor;
            Id = id;
        }
        public string GetState()
        {
            string av = Available ? "SI" : "NO";
            return $"Titulo: {Titulo}, Autor: {Autor}, Id: {Id}, Disponible: {av}";
        }
    }
}
