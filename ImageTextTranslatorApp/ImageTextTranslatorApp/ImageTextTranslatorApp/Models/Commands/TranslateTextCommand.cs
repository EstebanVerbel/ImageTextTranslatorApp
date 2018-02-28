using ImageTextTranslatorApp.Services;
using System;
using System.Windows.Input;

namespace ImageTextTranslatorApp.Models.Commands
{
    public class TranslateTextCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Tuple<string, string> _inputOutputText;

        public TranslateTextCommand(Tuple<string, string> inputOutputText)
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
            string text = _inputOutputText.Item1;
            // launch translate text service
            TranslateTextService translateTextService = new TranslateTextService(text);
            string translatedText = await translateTextService.Translate();

            // set text and translated text
            _inputOutputText = new Tuple<string, string>(text, translatedText);
        }
    }
}
