using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public ProfesorController(IUsuarioService service)
        {
            _service = service;
        }
        // GET: api/<ProfesorController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Profesor> profesores = _service.GetAllProffesors();
            if (profesores.Count == 0)
            {
                return NotFound("No hay profesores");
            }
            return Ok(profesores);
        }

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Profesor prof = _service.GetProfessorById(id);
            if (prof == null)
            {
                return NotFound("Profesor no encontrado");
            }
            return Ok(prof);
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public IActionResult Post([FromBody] Profesor prof)
        {
            try
            {
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
        public IActionResult Put(int id, [FromBody] Profesor prof)
        {
            try
            {
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
