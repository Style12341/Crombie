using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {

            List<Usuario> usuarios = _service.GetAllUsers();
            if (usuarios.Count == 0)
            {
                return NotFound("No hay usuarios");
            }
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           Usuario user = _service.GetUser(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok(user);
        }
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteUser(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
