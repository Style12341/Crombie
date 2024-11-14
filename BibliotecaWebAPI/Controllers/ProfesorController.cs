using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly UsuarioService _service = new UsuarioService();
        // GET: api/<ProfesorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<Profesor> profesores = _service.GetAllProffesors();
            if (profesores.Count == 0)
            {
                return new List<string> { "No hay profesores" };
            }
            return profesores.Select(e => JsonSerializer.Serialize<Profesor>(e));
        }

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Profesor prof = _service.GetProfessorById(id);
            return JsonSerializer.Serialize<Profesor>(prof);
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement value)
        {
            try
            {
                var prof = JsonSerializer.Deserialize<Profesor>(value);
                if (prof == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                prof = _service.CreateProfesor(prof);
                return Ok(prof);
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JsonElement value)
        {
            try
            {
                var prof = JsonSerializer.Deserialize<Profesor>(value.GetRawText());
                if (prof == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                prof.Id = id;
                _service.UpdateUser(prof);
                return Ok("Profesor updated successfully.");
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }
    }
}
