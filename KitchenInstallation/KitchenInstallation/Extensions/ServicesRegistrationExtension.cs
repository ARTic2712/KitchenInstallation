namespace KitchenInstallation.Extensions
{
    using System;
    using System.Reflection;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class ServicesRegistrationExtension
    {

        public static IServiceCollection AddCommonMvc(this IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }

        public static IServiceCollection AddApiCommonOptions(this IServiceCollection services,
            IConfiguration configuration)
        {

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
            return services;
        }
    }
}
