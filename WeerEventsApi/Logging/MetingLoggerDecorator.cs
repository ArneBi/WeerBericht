using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging
{
    public abstract class MetingLoggerDecorator : IMetingLogger
    {
        protected IMetingLogger _logger;

        protected MetingLoggerDecorator(IMetingLogger logger)
        {
            _logger = logger;
        }

        public virtual void Log(Meting meting)
        {
            _logger.Log(meting);
        }
    }
}
