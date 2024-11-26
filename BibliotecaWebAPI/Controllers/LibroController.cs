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
        public IActionResult Get()
        {
            List<Libro> libros = _service.GetAllBooks();
            if (libros.Count == 0)
            {
                return NotFound("No books");
            }

            return Ok(libros);
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Libro? libro = _service.GetBook(id);
            if (libro == null)
            {
                return NotFound("Book not found.");
            }
            return Ok(JsonSerializer.Serialize<Libro>(libro));
        }

        // POST api/<LibroController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro value)
        {
            try
            {
                var libro = value;
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
        public IActionResult Put(int id, [FromBody] Libro libro)
        {
            try
            {
                if (libro == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                libro.Id = id;
                if (_service.UpdateBook(libro) == null)
                {
                    return NotFound("Book not found.");
                }
                return Ok(libro);
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
            return NoContent();
        }
    }
}
