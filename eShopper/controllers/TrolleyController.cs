using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using System;
using Ports.Commands;

namespace eShopper.controllers
{
    [Produces("application/json")]
    [Route("api/Trolley")]
    public class TrolleyController : Controller
    {
        private IAmACommandProcessor commandProcessor;

        public TrolleyController(IAmACommandProcessor commandProcessor)
        {
            this.commandProcessor = commandProcessor;
        }

        [HttpPost]
        public IActionResult AddItem([FromBody]AddItemToTrolleyCommand command)
        {
            command.Id = Guid.NewGuid();
            commandProcessor.Send(command);
            return Ok();
        }
    }
}