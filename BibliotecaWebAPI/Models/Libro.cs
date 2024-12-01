using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaWebAPI.Models
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Id { get; set; }
        public bool Available { get; set; } = true;

        public Libro() { }
        public Libro(int id, string titulo, string autor, bool available = true)
        {
            Titulo = titulo;
            Autor = autor;
            Id = id;
            Available = available;
        }

        public override string? ToString()
        {
            string av = Available ? "SI" : "NO";
            return $"Titulo: {Titulo}, Autor: {Autor}, Id: {Id}, Disponible: {av}";
        }
    }
}
