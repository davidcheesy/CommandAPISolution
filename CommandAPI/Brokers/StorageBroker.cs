using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Brokers
{
    public partial class StorageBroker : DbContext
    {
        public StorageBroker(DbContextOptions<StorageBroker> options) : base(options)
        {
        }
        public DbSet<Command> CommandItems { get; set; }
    }
}
