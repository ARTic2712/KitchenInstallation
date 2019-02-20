namespace KitchenInstallation.Api
{
    using Microsoft.Extensions.Configuration;

    public static class ApiConfigurationBuilder
    {
        public static IConfiguration Build(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddJsonFile("appsettings.local.json", true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
