using System.Collections.Generic;
using CheatSheet.Models;

namespace CheatSheet.Data
{
    public interface ICommandRepo
    {
        Command GetById();
        IEnumerable<Command> GetByPlatform();
    }
}