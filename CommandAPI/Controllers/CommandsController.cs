using AutoMapper;
using CommandAPI.Brokers;
using CommandAPI.DTOs;
using CommandAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper mapper;
        public CommandsController(IStorageBroker storageBroker, IMapper mapper)
        {
            this.storageBroker = storageBroker;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands() 
            => Ok(mapper.Map<IEnumerable<CommandReadDto>>(storageBroker.GetAllCommands()));

        [Authorize]
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = storageBroker.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CommandReadDto>(commandItem));
        }
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);
            storageBroker.CreateCommand(commandModel);
            storageBroker.SaveChanges();
            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = storageBroker.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();
            
            mapper.Map(commandUpdateDto, commandModelFromRepo);
            storageBroker.UpdateCommand(commandModelFromRepo);
            storageBroker.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = storageBroker.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(commandToPatch, commandModelFromRepo);
            storageBroker.UpdateCommand(commandModelFromRepo);
            storageBroker.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = storageBroker.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            storageBroker.DeleteCommand(commandModelFromRepo);
            storageBroker.SaveChanges();
            return NoContent();
        }

    }
}
