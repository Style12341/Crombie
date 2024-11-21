﻿using BibliotecaWebAPI.Models;
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
        [HttpGet("history")]
        public IEnumerable<string> GetHistory()
        {
            var history = _service.GetHistory();
            if(history == null)
            {
                return ["No history found."];
            }
            return history.Select(h => JsonSerializer.Serialize<BibliotecaHistory>(h)).ToList();
        }

        [HttpGet("history/book/{id}")]
        public IEnumerable<string> GetBookHistory(int id)
        {
            var history = _service.GetBookHistory(id);
            if (history == null)
            {
                return ["Book not found."];
            }
            return history.Select(h => JsonSerializer.Serialize<BibliotecaHistory>(h)).ToList();
        }
        [HttpGet("history/user/{id}")]
        public IEnumerable<string> GetUserHistory(int id)
        {
            var history = _service.GetUserHistory(id);
            if(history == null)
            {
                return ["User not found."];
            }
            return history.Select(h => JsonSerializer.Serialize<BibliotecaHistory>(h)).ToList();
        }

    }
}
