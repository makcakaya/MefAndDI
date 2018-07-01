using Mef.Extension;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Mef.ConsoleExtension
{
    [Export(typeof(IExtension))]
    public sealed class ConsoleExtension : IExtension
    {
        public void Initialize()
        {
            // No initialization required for this type.
        }

        public void Run()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine($"{nameof(ConsoleExtension)} is running.");
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }
            });
        }
    }
}
