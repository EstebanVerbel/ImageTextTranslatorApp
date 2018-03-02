using ImageTextTranslatorApp.Services;
using System;
using System.Windows.Input;

namespace ImageTextTranslatorApp.Models.Commands
{
    public class TranslateTextCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private string[] _inputOutputText;

        public TranslateTextCommand(string[] inputOutputText)
        {
            // TODO: Request target language here. 
            // For now from language will always be english
            _inputOutputText = inputOutputText;
        }
        
        public bool CanExecute(object parameter)
        {
            // TODO: Only if device is connected to internet
            return true;
        }

        public async void Execute(object parameter)
        {
            string text = _inputOutputText[0];

            // launch translate text service
            TranslateTextService translateTextService = new TranslateTextService(text);
            // set text and translated text
            _inputOutputText[1] = await translateTextService.Translate();
        }
    }
}
