namespace KitchenInstallation.Contracts
{
    using Microsoft.Extensions.Logging;

    public static class LoggingEvents
    {
        /// <summary>
        ///     Gets application lifecycle events, such as start/stop.
        /// </summary>
        public static EventId AppLifecycle => new EventId(1001, nameof(AppLifecycle));

        /// <summary>
        ///     Gets represents EventId for Http Request log.
        /// </summary>
        public static EventId LogRequest => new EventId(1002, nameof(LogRequest));

        /// <summary>
        ///     Gets represents EventId for Http Response log.
        /// </summary>
        public static EventId LogResponse => new EventId(1003, nameof(LogResponse));

        /// <summary>
        ///     Gets event Id for logged handled exception.
        /// </summary>
        public static EventId UnhandledException => new EventId(1004, nameof(UnhandledException));

        public static EventId SberbankPayment => new EventId(1005, nameof(SberbankPayment));

        public static EventId PayPalPayment => new EventId(1006, nameof(PayPalPayment));
    }
}
