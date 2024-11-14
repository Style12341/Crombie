using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly BibliotecaService _service = new();
        // GET: api/<BibliotecaController>
        [HttpPost("lend")]
        public IActionResult LendBook([FromBody] JsonElement value)
        {
            var ids = JsonSerializer.Deserialize<BibliotecaOperationDTO>(value);
            if (ids == null)
            {
                return BadRequest("Invalid JSON data.");
            }
            if (_service.LendBook(ids))
                return Ok("Book lent successfully.");
            return BadRequest("Book lending failed.");
        }
        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] JsonElement value)
        {
            var ids = JsonSerializer.Deserialize<BibliotecaOperationDTO>(value);
            if (ids == null)
            {
                return BadRequest("Invalid JSON data.");
            }
            if (_service.ReturnBook(ids))
                return Ok("Book returned successfully.");
            return BadRequest("User doesn't have the book to return");
        }

    }
}
