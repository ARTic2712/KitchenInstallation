namespace KitchenInstallation.Api
{
    using System.Reflection;
    using Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using Middlewares;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services
                .AddCommonMvc()
                .AddOptions()
                .AddApiCommonOptions(Configuration)
                .RegisterSwagger("Kitchen installation API", typeof(Startup).GetTypeInfo().Assembly)
                .RegisterServices();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IApplicationLifetime applicationLifetime,
            ApplicationLifetimeHandler applicationLifetimeHandler)
        {
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin());
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSwaggerWithUI(typeof(Startup).GetTypeInfo().Assembly);
            app.UseMvc();

            applicationLifetime.ApplicationStarted.Register(applicationLifetimeHandler.ApplicationStarted);
            applicationLifetime.ApplicationStopped.Register(applicationLifetimeHandler.ApplicationStopped);
            applicationLifetime.ApplicationStopping.Register(applicationLifetimeHandler.ApplicationStopping);
        }
    }
}
