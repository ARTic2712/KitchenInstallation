namespace KitchenInstallation.Api
{
    using System;
    using System.IO;
    using Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using Settings;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHost().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateWebHost()
        {
            var configuration = GetConfiguration();

            return new WebHostBuilder()
                .UseKestrel(configuration.GetSection("Host").Get<HostSettings>())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureAndUseSerilog(configuration)
                .Build();
        }

        private static IConfiguration GetConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? EnvironmentName.Production;
            return ApiConfigurationBuilder.Build(Directory.GetCurrentDirectory(), environmentName);
        }
    }
}
