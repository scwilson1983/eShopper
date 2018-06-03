using Config;
using Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter.AspNetCore;
using Ports.Trolley;
using System.IO;

namespace eShopper
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AppBootstrapper.RegisterDependencies(services);
            services.AddBrighter()
                    .AsyncHandlersFromAssemblies(typeof(AddItemToTrolleyHandler).Assembly);
            services.AddMvc();
            services.Configure<EventStoreConfig>(Configuration.GetSection("EventStore"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.WebRootPath)
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("eShopper API");
            });
        }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .AddJsonFile(Path.Combine(env.ContentRootPath, "appSettings.json"))
               .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
        }
    }
}
