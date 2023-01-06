using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CheatSheet.Data;
using CheatSheet.Dtos;
using CheatSheet.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("{id:int}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var repoCmd = _repository.GetCommandById(id);
            if (repoCmd is null) return NotFound();
            
            _mapper.Map(updateDto, repoCmd);
            _repository.UpdateCommand(repoCmd);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var repoCmd = _repository.GetCommandById(id);
            if (repoCmd is null) return NotFound();

            var cmdToPatch = _mapper.Map<CommandUpdateDto>(repoCmd);
            patchDocument.ApplyTo(cmdToPatch, ModelState);
            if (!TryValidateModel(cmdToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(cmdToPatch, repoCmd);
            _repository.UpdateCommand(repoCmd);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command is null) return NotFound();
            
            _repository.DeleteCommand(command);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}