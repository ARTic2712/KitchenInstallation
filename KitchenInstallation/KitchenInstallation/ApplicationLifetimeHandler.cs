namespace KitchenInstallation.Api
{
    using Microsoft.Extensions.Logging;
    using Contracts;

    public class ApplicationLifetimeHandler
    {
        private readonly ILogger _logger;

        public ApplicationLifetimeHandler(ILogger<ApplicationLifetimeHandler> logger)
        {
            _logger = logger;
        }

        public virtual void ApplicationStarted()
        {
            _logger.LogInformation(LoggingEvents.AppLifecycle, "Application started.");
        }

        public virtual void ApplicationStopped()
        {
            _logger.LogInformation(LoggingEvents.AppLifecycle, "Application stopped.");
        }

        public virtual void ApplicationStopping()
        {
            _logger.LogInformation(LoggingEvents.AppLifecycle, "Application stopping.");
        }
    }
}
