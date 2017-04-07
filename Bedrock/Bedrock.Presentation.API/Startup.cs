using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Bedrock.Infrastructure.IoC;
using Bedrock.Infrastructure.IoC.Autofac;
using Bedrock.Infrastructure.Logger;

namespace Bedrock.API
{
    public class Startup
    {
        public IApplicationContainerManager ContainerManager { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug)
               .Enrich.FromLogContext()
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddOptions();

            // Create the IServiceProvider based on the container.
            ContainerManager = new AutofacIoCManager();
            return ContainerManager.PopulateAndGetServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime, IBedrockLogManager bedrockLogManager)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            loggerFactory.AddSerilog(bedrockLogManager.CreateLogger());

            app.UseMvc();

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            appLifetime.ApplicationStopped.Register(() => this.ContainerManager.Dispose());
        }
    }
}
