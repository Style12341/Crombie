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
        public IActionResult Get()
        {
            List<Estudiante> estudiantes = _service.GetAllStudents();
            if (estudiantes.Count == 0)
            {
                return NotFound();
            }
            return Ok(estudiantes);
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Estudiante est;
            try
            {
                est = _service.GetStudentById(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(est);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public IActionResult Post([FromBody] Estudiante est)
        {
            try
            {
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
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estudiante est)
        {
            try
            {
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
