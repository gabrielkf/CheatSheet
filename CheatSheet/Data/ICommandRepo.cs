using System.Collections.Generic;
using CheatSheet.Models;

namespace CheatSheet.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        Command GetCommandById(int id);
        IEnumerable<Command> GetAllCommands();
        IEnumerable<Command> GetCommandsByPlatform(string platform);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
    }
}