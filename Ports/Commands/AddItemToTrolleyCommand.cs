using System;
using Paramore.Brighter;

namespace Ports.Commands
{
    public class AddItemToTrolleyCommand : IRequest
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
