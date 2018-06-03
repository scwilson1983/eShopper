using System.Threading.Tasks;

namespace Ports.Events
{
    public interface IEventStoreRepository
    {
        Task Add<T>(StoreEvent<T> storeEvent) where T : class;
    }
}
