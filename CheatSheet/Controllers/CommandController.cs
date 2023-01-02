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
        private readonly MockCommandRepo _repository = new MockCommandRepo();
        
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAll()
        {
            var allCommands = _repository.GetAll();
            return Ok(allCommands);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Command> GetById(int id)
        {
            var command = _repository.GetById(id);
            return Ok(command);
        }
    }
}