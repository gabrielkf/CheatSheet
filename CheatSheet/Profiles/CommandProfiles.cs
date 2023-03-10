
using AutoMapper;
using CheatSheet.Dtos;
using CheatSheet.Models;

namespace CheatSheet.Profiles
{
    public class CommandProfiles : Profile 
    {
        public CommandProfiles()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}