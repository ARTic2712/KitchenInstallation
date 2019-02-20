namespace KitchenInstallation.Api.Extensions
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.AspNetCore.Server.Kestrel.Https;
    using Settings;

    public static class KestrelWebHostBuilderExtension
    {
        private const string Http = "HTTP";

        private const string Https = "HTTPS";

        public static IWebHostBuilder UseKestrel(this IWebHostBuilder hostBuilder, HostSettings hostSettings)
        {
            hostBuilder.UseKestrel(options => SetHost(options, hostSettings));

            return hostBuilder;
        }

        private static void SetHost(KestrelServerOptions options, HostSettings hostSettings)
        {
            foreach (var endpoint in hostSettings.Endpoints.Values)
            {
                if (!endpoint.IsEnabled)
                {
                    continue;
                }

                var address = IPAddress.Parse(endpoint.Address);

                switch (endpoint.Scheme.ToUpperInvariant())
                {
                    case Http:
                        options.Listen(address, endpoint.Port);
                        break;
                    case Https:
                        options.Listen(address, endpoint.Port, opt => opt.UseHttps(GetHttpsConnectionOptions()));
                        break;
                    default:
                        throw new NotImplementedException($"The scheme [{endpoint.Scheme}] is not supported.");
                }
            }
        }

        private static HttpsConnectionAdapterOptions GetHttpsConnectionOptions()
        {
            return new HttpsConnectionAdapterOptions();
        }
    }
}
