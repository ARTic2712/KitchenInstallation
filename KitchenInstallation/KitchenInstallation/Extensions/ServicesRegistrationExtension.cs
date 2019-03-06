namespace KitchenInstallation.Api.Extensions
{
    using System;
    using System.Reflection;
    using Business.KitchenManagement;
    using Infrastructure.Azure;
    using Interfaces.Business.KitchenManagement;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class ServicesRegistrationExtension
    {

        public static IServiceCollection AddCommonMvc(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }

        public static IServiceCollection AddApiCommonOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            return services;
        }

        public static IServiceCollection RegisterSwagger(
            this IServiceCollection services,
            string documentTitle,
            Assembly assembly,
            Action<SwaggerGenOptions> additionalSetupAction = null)
        {
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
                          Assembly.GetEntryAssembly().GetName().Version.ToString();

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc(version, new Info {Title = documentTitle, Version = version});
                    additionalSetupAction?.Invoke(options);
                });

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationLifetimeHandler>();

            services.AddScoped<ITabletopManager, TabletopManager>();

            return services;
        }
    }
}
