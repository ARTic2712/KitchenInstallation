namespace KitchenInstallation.Api.Extensions
{
    using Infrastructure.Logging;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public static class SerilogWebHostBuilderExtension
    {
        public static IWebHostBuilder ConfigureAndUseSerilog(this IWebHostBuilder builder, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.With<UtcTimestampEnricher>()
                .CreateLogger();

            Log.Logger = logger;

            builder.UseSerilog(logger);

            return builder;
        }
    }
}
