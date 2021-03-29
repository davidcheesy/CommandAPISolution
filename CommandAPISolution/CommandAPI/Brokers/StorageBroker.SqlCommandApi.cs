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
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            
            CommandItems.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            CommandItems.Remove(cmd);

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
            
        }

        bool IStorageBroker.SaveChanges() => SaveChanges() >= 0;
    }
}
