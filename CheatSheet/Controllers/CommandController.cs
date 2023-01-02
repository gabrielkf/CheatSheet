using System.Collections.Generic;
using System.Linq;
using CheatSheet.Data;
using CheatSheet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheatSheet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepo _repository;

        public CommandController(ICommandRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Command>> GetAll()
        {
            var allCommands = _repository.GetAll();
            return Ok(allCommands);
        }
        
        [HttpGet("{platform}")]
        public ActionResult<IEnumerable<Command>> GetByPlatform(string platform)
        {
            var byPlatform = _repository.GetByPlatform(platform);
            if (!byPlatform.Any()) return NotFound();
            return Ok(byPlatform);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Command> GetById(int id)
        {
            var command = _repository.GetById(id);
            if (command is null) return NotFound();
            return Ok(command);
        }
    }
}