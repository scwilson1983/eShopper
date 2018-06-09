using Paramore.Brighter;
using Ports.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Ports.Trolley
{
    public class AddItemToTrolleyHandler : RequestHandlerAsync<AddItemToTrolleyCommand>
    {
        private readonly IEventStoreRepository eventStoreRepository;
        private const string EventType = "ItemAddedToTrolley";

        public AddItemToTrolleyHandler(IEventStoreRepository eventStoreRepository)
        {
            this.eventStoreRepository = eventStoreRepository;
        }

        public override async Task<AddItemToTrolleyCommand> HandleAsync(AddItemToTrolleyCommand command, CancellationToken ct)
        {
            var addItemEvent = new StoreEvent<AddItemToTrolleyCommand>(command, EventType);
            await eventStoreRepository.Add(addItemEvent);

            return await base.HandleAsync(command, ct).ConfigureAwait(ContinueOnCapturedContext);
        }
    }
}
