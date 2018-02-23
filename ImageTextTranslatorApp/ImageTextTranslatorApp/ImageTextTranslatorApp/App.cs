using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Services;

namespace ImageTextTranslatorApp
{
    public partial class App
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Picture>, DataStore>();
        }
    }
}