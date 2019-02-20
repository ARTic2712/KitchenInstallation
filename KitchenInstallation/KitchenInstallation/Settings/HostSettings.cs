namespace KitchenInstallation.Api.Settings
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class HostSettings
    {
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Endpoints collection should have setter.")]
        public Dictionary<string, EndpointSettings> Endpoints { get; set; }
    }
}
