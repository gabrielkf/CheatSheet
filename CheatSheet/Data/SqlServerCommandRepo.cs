using System.Collections.Generic;
using System.Linq;
using CheatSheet.Models;

namespace CheatSheet.Data
{
    public class SqlServerCommandRepo : ICommandRepo
    {
        private readonly DataContext _context;

        public SqlServerCommandRepo(DataContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.SingleOrDefault(command => command.Id == id);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public IEnumerable<Command> GetCommandsByPlatform(string platform)
        {
            return _context.Commands.Where(command => 
                command.Platform.ToLower() == platform.ToLower());
        }

        public void CreateCommand(Command command)
        {
            if (command is null) throw new System.ArgumentNullException();
            _context.Commands.Add(command);
        }

        public void UpdateCommand(Command command)
        {
            // nothing
        }
    }
}