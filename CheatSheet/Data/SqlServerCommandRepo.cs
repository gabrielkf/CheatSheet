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
        
        public Command GetById(int id)
        {
            return _context.Commands.SingleOrDefault(command => command.Id == id);
        }

        public IEnumerable<Command> GetAll()
        {
            return _context.Commands.ToList();
        }

        public IEnumerable<Command> GetByPlatform(string platform)
        {
            return _context.Commands.Where(command => 
                command.Platform.ToLower() == platform.ToLower());
        }
    }
}