namespace KitchenInstallation.Infrastructure.Logging
{
    using Serilog.Core;
    using Serilog.Events;

    public class UtcTimestampEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory logEventPropertyFactory)
        {
            logEvent.AddPropertyIfAbsent(
                logEventPropertyFactory.CreateProperty("UtcTimestamp", logEvent.Timestamp.ToUniversalTime()));
        }
    }
}
