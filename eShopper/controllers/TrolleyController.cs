using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using System;
using Ports.Trolley;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddItem([FromBody]AddItemToTrolleyCommand command)
        {
            command.Id = Guid.NewGuid();
            await commandProcessor.SendAsync(command).ConfigureAwait(false);
            return Ok();
        }
    }
}