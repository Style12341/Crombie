using BibliotecaApp;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public EstudianteController(IUsuarioService service)
        {
            _service = service;
        }
        // GET: api/<EstudianteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<Estudiante> estudiantes = _service.GetAllStudents();
            if (estudiantes.Count == 0)
            {
                return new List<string> { "No hay estudiantes" };
            }
            return estudiantes.Select(e => JsonSerializer.Serialize<Estudiante>(e));
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Estudiante est = _service.GetStudentById(id);
            return JsonSerializer.Serialize<Estudiante>(est);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement value)
        {
            try
            {
                var est = JsonSerializer.Deserialize<Estudiante>(value);
                if (est == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                est = _service.CreateEstudiante(est);
                return Ok(est);
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JsonElement value)
        {
            try
            {
                var est = JsonSerializer.Deserialize<Estudiante>(value.GetRawText());
                if (est == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                est.Id = id;
                _service.UpdateUser(est);
                return Ok("Estudiante updated successfully.");
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }
    }
}
