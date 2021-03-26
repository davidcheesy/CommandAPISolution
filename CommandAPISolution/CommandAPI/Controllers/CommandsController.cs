using CommandAPI.Brokers;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IStorageBroker storageBroker;
        public CommandsController(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands() => Ok(storageBroker.GetAllCommands());
        
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = storageBroker.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}
