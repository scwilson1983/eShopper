using System;
using Paramore.Brighter;

namespace Ports.Trolley
{
    public class AddItemToTrolleyCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid TrolleyId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
