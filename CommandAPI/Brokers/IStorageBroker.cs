using CommandAPI.Models;
using System.Collections.Generic;

namespace CommandAPI.Brokers
{
    public interface IStorageBroker
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);

    }
}
