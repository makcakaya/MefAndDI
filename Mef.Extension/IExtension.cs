namespace Mef.Extension
{
    public interface IExtension
    {
        /// <summary>
        /// Entry point. Initialize the extension, register dependencies etc.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Run the extension. Must be called after Initialize.
        /// </summary>
        void Run();
    }
}
