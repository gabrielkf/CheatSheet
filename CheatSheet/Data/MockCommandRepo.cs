using System;
using System.Collections.Generic;
using System.Linq;
using CheatSheet.Models;

namespace CheatSheet.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return MockCommands.SingleOrDefault(command => command.Id == id);
        }

        public IEnumerable<Command> GetAllCommands() => MockCommands;

        public IEnumerable<Command> GetCommandsByPlatform(string platform)
        {
            return MockCommands.Where(command => command.Platform == platform);
        }

        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Command> MockCommands => new List<Command>
        {
            new Command()
            {
                Id = 1,
                Description = "Scaffolds new .net webapi project",
                Line = "dotnet new webapi <name>",
                Platform = "dotnet"
            },
            new Command()
            {
                Id = 2,
                Description = "Returns commits hash and message",
                Line = "git log --oneline",
                Platform = "git"
            },
            new Command()
            {
                Id = 3,
                Description = "Show alterations and included files",
                Line = "git status",
                Platform = "git"
            },
        };
    }
}