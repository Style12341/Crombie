using BibliotecaApp;
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
        public IEnumerable<string> Get()
        {

            List<Usuario> usuarios = _service.GetAllUsers();
            if (usuarios.Count == 0)
            {
                return new List<string> { "No hay usuarios" };
            }
            return usuarios.Select(u => JsonSerializer.Serialize<Usuario>(u));
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
           Usuario user = _service.GetUser(id);
            if (user == null)
            {
                return "No se encontró el usuario";
            }
            return JsonSerializer.Serialize<Usuario>(user);
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
            return Ok("Usuario deleted successfully.");
        }
    }
}
