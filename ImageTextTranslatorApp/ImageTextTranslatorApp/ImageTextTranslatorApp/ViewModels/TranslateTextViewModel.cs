using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Models.Commands;
using ImageTextTranslatorApp.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageTextTranslatorApp.ViewModels
{
    public class TranslateTextViewModel : BaseViewModel
    {
        public string[] InputOutputText { private set; get; }
        
        public string TranslatedText { get { return InputOutputText[1]; } }

        public TranslateTextViewModel()
        {
            Title = "Translate Text";
        }

        /// <summary>
        /// Gets Picture from DataStore
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetImageText()
        {
            // get picture from data store
            Picture picture = await DataStore.GetItemAsync("");

            string imageText = "No Text has been read yet";

            if (picture != null)
            {
                imageText = picture.Text;
                InputOutputText = new string[] { imageText, "" };
            }
            
            return imageText;
        }
        
        private ICommand translateTextCommand;
        /// <summary>
        /// ICommand Gets Translated Text
        /// </summary>
        public ICommand GetTranslateTextCommand
        {
            get
            {
                return (translateTextCommand = new TranslateTextCommand(InputOutputText));
            }
        }
        
    }
}
