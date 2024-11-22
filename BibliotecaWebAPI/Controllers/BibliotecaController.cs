using BibliotecaWebAPI.Models;
using BibliotecaWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _service;
        public BibliotecaController(IBibliotecaService service)
        {
            _service = service;
        }
        // GET: api/<BibliotecaController>
        [HttpPost("lend")]
        public IActionResult LendBook([FromBody] BibliotecaOperationDTO operation)
        {
            if (operation == null)
            {
                return BadRequest("Invalid JSON data.");
            }
            if (_service.LendBook(operation))
                return Ok("Book lent successfully.");
            return BadRequest("Book lending failed.");
        }
        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] BibliotecaOperationDTO operation)
        {
            if (operation == null)
            {
                return BadRequest("Invalid JSON data.");
            }
            if (_service.ReturnBook(operation))
                return Ok("Book returned successfully.");
            return BadRequest("User doesn't have the book to return");
        }
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var history = _service.GetHistory();
            if(history == null)
            {
                return NotFound("No history found.");
            }
            return Ok(history);
        }

        [HttpGet("history/book/{id}")]
        public IActionResult GetBookHistory(int id)
        {
            var history = _service.GetBookHistory(id);
            if (history == null)
            {
                return NotFound($"Book with id: {id} not found");
            }
            return Ok(history);
        }
        [HttpGet("history/user/{id}")]
        public IActionResult GetUserHistory(int id)
        {
            var history = _service.GetUserHistory(id);
            if(history == null)
            {
                return NotFound($"User with id: {id} not found");
            }
            return Ok(history);
        }

    }
}
