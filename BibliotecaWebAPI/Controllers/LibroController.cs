using BibliotecaApp;
using BibliotecaWebAPI.Persistance;
using BibliotecaWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;
        public LibroController(ILibroService service)
        {
            _service = service;
        }

        // GET: api/<LibroController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<Libro> libros = _service.GetAllBooks();
            if (libros.Count == 0)
            {
                return new List<string> { "No hay libros" };
            }
            return libros.Select(libro => JsonSerializer.Serialize<Libro>(libro));
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Libro? libro = _service.GetBook(id);
            if (libro == null)
            {
                return "No se encontró el libro";
            }
            return JsonSerializer.Serialize<Libro>(libro);
        }

        // POST api/<LibroController>
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement value)
        {
            try
            {
                var libro = JsonSerializer.Deserialize<Libro>(value.GetRawText());
                if (libro == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                libro = _service.CreateBook(libro);
                return Ok(JsonSerializer.Serialize<Libro>(libro));
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JsonElement value)
        {
            try
            {
                var libro = JsonSerializer.Deserialize<Libro>(value.GetRawText());
                if (libro == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                libro.Id = id;
                _service.UpdateBook(libro);
                return Ok("Libro updated successfully.");
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteBook(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Libro deleted successfully.");
        }
    }
}
