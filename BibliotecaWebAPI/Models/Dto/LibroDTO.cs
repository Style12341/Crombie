namespace BibliotecaWebAPI.Models.Dto
{
    public class LibroDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Available { get; set; } = true;
    }
}
