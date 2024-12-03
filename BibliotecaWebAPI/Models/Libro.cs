using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        [AllowNull]
        private Usuario _prestante;
        private int prestante_id;
        [AllowNull]
        public Usuario Prestante
        {
            get => _prestante; set
            {
                if (value is Usuario user)
                {
                    Available = false;
                    _prestante = user;
                    prestante_id = user.Id;
                }
                else
                {
                    Available = true;
                    _prestante = null;
                }
            }
        }


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
