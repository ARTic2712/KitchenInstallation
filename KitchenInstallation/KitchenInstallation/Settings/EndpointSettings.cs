namespace KitchenInstallation.Api.Settings
{
    public class EndpointSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether Endpoint is bound or not.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the scheme. E.g. "http" or "https".
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        ///     Gets or sets IP Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets port number.
        /// </summary>
        public int Port { get; set; }
    }
}
