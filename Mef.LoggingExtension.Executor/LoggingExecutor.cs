using System;

namespace Mef.LoggingExtension.Executor
{
    public sealed class LoggingExecutor
    {
        private readonly IExecutorLogger _logger;

        public LoggingExecutor(IExecutorLogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
