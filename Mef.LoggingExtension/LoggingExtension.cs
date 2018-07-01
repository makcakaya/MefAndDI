using Mef.Extension;
using Mef.LoggingExtension.Executor;
using NLog;
using NLog.Config;
using SimpleInjector;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Mef.LoggingExtension
{
    [Export(typeof(IExtension))]
    public sealed class LoggingExtension : IExtension
    {
        private readonly Container _container = new Container();

        public void Initialize()
        {
            SimpleConfigurator.ConfigureForConsoleLogging();
            _container.Register<ILogger>(() => LogManager.GetCurrentClassLogger(), Lifestyle.Singleton);
            _container.Register<IExecutorLogger, ExecutorLoggerAdapter>(Lifestyle.Singleton);
            _container.Register<LoggingExecutor>(Lifestyle.Singleton);

            // Fail fast.
            _container.Verify();
        }

        public void Run()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    _container.GetInstance<LoggingExecutor>().Log($"{nameof(LoggingExtension)} is running.");
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }
            });
        }
    }
}
