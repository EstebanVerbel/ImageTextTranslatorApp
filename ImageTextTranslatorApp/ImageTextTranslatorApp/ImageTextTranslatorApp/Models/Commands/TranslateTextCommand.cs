using ImageTextTranslatorApp.Services;
using System;
using System.Windows.Input;

namespace ImageTextTranslatorApp.Models.Commands
{
    public class TranslateTextCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Picture _picture;

        public TranslateTextCommand(Picture picture)
        {
            _picture = picture;
            // TODO: Request target language here. 
            // For now from language will always be english
        }
        
        public bool CanExecute(object parameter)
        {
            // TODO: Only if device is connected to internet
            return true;
        }

        public async void Execute(object parameter)
        {
            TranslateTextService translateTextService = new TranslateTextService();
            string translatedText = await translateTextService.Translate();
            _picture.TranslatedText = translatedText;
        }
    }
}
