using Config;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Ports.Events;
using System.Threading.Tasks;

namespace Adapters
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreConfig config;
        private readonly MongoClient client;
        private const string EventStoreDb = "Events";

        public EventStoreRepository(IOptions<EventStoreConfig> settings)
        {
            this.config = settings.Value;
            this.client = new MongoClient(config.ConnectionString);
        }

        public async Task Add<T>(StoreEvent<T> storeEvent) where T : class
        {
            var bson = BuildBson(storeEvent);
            var db = client.GetDatabase(nameof(EventStoreDb));
            var collection = db.GetCollection<BsonDocument>(EventStoreDb);
            await collection.InsertOneAsync(bson);
        }

        private BsonDocument BuildBson<T>(StoreEvent<T> storeEvent) where T : class
        {
            return new BsonDocument
            {
                { nameof(storeEvent.TimeGenerated), BsonValue.Create(storeEvent.TimeGenerated) },
                { nameof(storeEvent.Type), BsonValue.Create(storeEvent.Type) },
                { nameof(storeEvent.Body), BsonValue.Create(JsonConvert.SerializeObject(storeEvent.Body)) }
            };
        }
    }
}
