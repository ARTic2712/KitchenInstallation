namespace KitchenInstallation.Api.Extensions
{
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;

    public static class SwaggerExtensions
    {
        /// <summary>
        ///     Swagger JSON endpoint start path
        /// </summary>
        public const string SwaggerJSONRoute = "swagger";

        /// <summary>
        ///     Route to Swagger UI.
        /// </summary>
        public const string SwaggerUIRoute = "api-reference";

        public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder appBuilder, Assembly assembly)
        {
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
                          Assembly.GetEntryAssembly().GetName().Version.ToString();

            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint($"/{SwaggerJSONRoute}/{version}/swagger.json", version);
                    c.RoutePrefix = SwaggerUIRoute;
                });

            return appBuilder;
        }
    }
}
