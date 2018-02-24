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
        public async Task<string> GetImageText()
        {
            // get picture from data store
            Picture picture = await DataStore.GetItemAsync("");

            string imageText = "No Text has been read yet";

            if (picture != null)
                 imageText = picture.Text;

            return imageText;
        }
        
    }
}
