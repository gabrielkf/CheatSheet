using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CheatSheet.Data;
using CheatSheet.Dtos;
using CheatSheet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheatSheet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            var allCommands = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(allCommands));
        }
        
        [HttpGet("{platform}")]
        public ActionResult<IEnumerable<CommandReadDto>> GetByPlatform(string platform)
        {
            var byPlatform = _repository.GetByPlatform(platform);
            if (!byPlatform.Any()) return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(byPlatform));
        }

        [HttpGet("{id:int}")]
        public ActionResult<CommandReadDto> GetById(int id)
        {
            var command = _repository.GetById(id);
            if (command is null) return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }
    }
}