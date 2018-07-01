using System;

namespace Mef.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var extensionManager = new ExtensionManager("Extensions");
            var extensions = extensionManager.Initialize();

            foreach (var extension in extensions)
            {
                extension.Run();
            }

            Console.ReadLine();
        }
    }
}
