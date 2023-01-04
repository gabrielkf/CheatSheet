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
            var allCommands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(allCommands));
        }
        
        [HttpGet("{platform}")]
        public ActionResult<IEnumerable<CommandReadDto>> GetByPlatform(string platform)
        {
            var byPlatform = _repository.GetCommandsByPlatform(platform);
            if (!byPlatform.Any()) return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(byPlatform));
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public ActionResult<CommandReadDto> GetById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command is null) return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(command);
            if (!_repository.SaveChanges()) return UnprocessableEntity();

            var readDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetById), new {Id = command.Id}, readDto);
        }
    }
}