using CommandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Brokers
{
    public partial class StorageBroker : IStorageBroker
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return CommandItems.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        bool IStorageBroker.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
