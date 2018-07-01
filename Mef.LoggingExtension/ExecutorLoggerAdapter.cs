using Mef.LoggingExtension.Executor;
using NLog;
using System;

namespace Mef.LoggingExtension
{
    public sealed class ExecutorLoggerAdapter : IExecutorLogger
    {
        private readonly ILogger _logger;

        public ExecutorLoggerAdapter(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Log(string message)
        {
            _logger.Info(message);
        }
    }
}
