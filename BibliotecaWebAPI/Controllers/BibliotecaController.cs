using BibliotecaWebAPI.Models.Dto;
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
            _service.LendBook(operation);
            return Ok("Book lent successfully.");
        }
        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] BibliotecaOperationDTO operation)
        {
            if (operation == null)
            {
                return BadRequest("Invalid JSON data.");
            }
            _service.ReturnBook(operation);
            return Ok("Book returned successfully.");
        }
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var history = _service.GetHistory();
            return Ok(history);
        }

        [HttpGet("history/book/{id}")]
        public IActionResult GetBookHistory(int id)
        {
            var history = _service.GetBookHistory(id);
            return Ok(history);
        }
        [HttpGet("history/user/{id}")]
        public IActionResult GetUserHistory(int id)
        {
            var history = _service.GetUserHistory(id);
            return Ok(history);
        }

    }
}
