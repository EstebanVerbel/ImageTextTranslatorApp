using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.ViewModel;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        public Picture Picture { get; set; }

        public PictureViewModel()
        {
            Title = "Picture";
        }

    }
}
