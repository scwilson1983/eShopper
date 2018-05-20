using Paramore.Brighter;
using Ports.Commands;

namespace Ports.Handlers
{
    public class AddItemToTrolleyHandler : RequestHandler<AddItemToTrolleyCommand>
    {
        public override AddItemToTrolleyCommand Handle(AddItemToTrolleyCommand command)
        {
            return command;
        }
    }
}
