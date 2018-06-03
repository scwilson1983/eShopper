using Adapters;
using Microsoft.Extensions.DependencyInjection;
using Ports.Events;

namespace Dependencies
{
    public class AppBootstrapper
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IEventStoreRepository, EventStoreRepository>();
        }
    }
}
