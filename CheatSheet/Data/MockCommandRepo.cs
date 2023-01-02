using System;
using System.Collections.Generic;
using System.Linq;
using CheatSheet.Models;

namespace CheatSheet.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public Command GetById(int id)
        {
            return MockCommands.SingleOrDefault(command => command.Id == id);
        }

        public IEnumerable<Command> GetAll() => MockCommands;

        public IEnumerable<Command> GetByPlatform(string platform)
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