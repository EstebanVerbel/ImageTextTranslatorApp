using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Interfaces;
using ImageTextTranslatorApp.Services;
using ImageTextTranslatorApp.Model;

namespace ImageTextTranslatorApp
{
    public partial class App
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}