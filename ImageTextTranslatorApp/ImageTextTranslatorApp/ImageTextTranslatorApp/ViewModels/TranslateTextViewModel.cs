using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.ViewModel;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.ViewModels
{
    public class TranslateTextViewModel : BaseViewModel
    {
        
        public TranslateTextViewModel()
        {
            Title = "Translate Text";
        }

        /// <summary>
        /// Gets Picture from DataStore
        /// </summary>
        /// <returns></returns>
        public async Task<Picture> GetPicture()
        {
            return await DataStore.GetItemAsync("");
        }
        
    }
}
