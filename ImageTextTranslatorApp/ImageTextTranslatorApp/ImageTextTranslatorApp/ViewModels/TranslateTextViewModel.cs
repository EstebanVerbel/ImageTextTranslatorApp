using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.ViewModel;

namespace ImageTextTranslatorApp.ViewModels
{
    public class TranslateTextViewModel : BaseViewModel
    {
        public Picture Picture { get; set; }

        public TranslateTextViewModel()
        {
            Title = "Translate Text";
        }
        
    }
}
