using Mef.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Mef.App
{
    public sealed class ExtensionManager
    {
        private readonly CompositionContainer _compositionContainer;
        private IEnumerable<Lazy<IExtension>> _extensions;

        public ExtensionManager(string extensionsDirectory)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(extensionsDirectory));

            _compositionContainer = new CompositionContainer(catalog);
        }

        public IEnumerable<IExtension> Initialize()
        {
            try
            {
                _compositionContainer.ComposeParts();
                _extensions =_compositionContainer.GetExports<IExtension>();

                var extensions = new List<IExtension>();
                foreach (var extension in _extensions)
                {
                    extension.Value.Initialize();
                    extensions.Add(extension.Value);
                }

                return extensions;
            }
            catch (CompositionException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
