using System;
using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Services;

namespace ImageTextTranslatorApp
{
    public class App
    {

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}
