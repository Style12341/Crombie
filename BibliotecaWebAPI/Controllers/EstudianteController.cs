using BibliotecaWebAPI;
using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Models.Dto;
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
            Estudiante est = _service.GetStudentById(id);
            return Ok(est);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public IActionResult Post([FromBody] EstudianteDTO est)
        {
            try
            {
                if (est == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                Estudiante estudiante = new Estudiante();
                estudiante.Nombre = est.Nombre;
                estudiante = _service.CreateEstudiante(estudiante);
                return Ok(estudiante);
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EstudianteDTO est)
        {
            try
            {
                if (est == null)
                {
                    return BadRequest("Invalid JSON data.");
                }
                Estudiante estudiante = new Estudiante();
                estudiante.Nombre = est.Nombre;
                estudiante.Id = id;
                _service.UpdateUser(estudiante);
                return Ok("Estudiante updated successfully.");
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
        }
    }
}
