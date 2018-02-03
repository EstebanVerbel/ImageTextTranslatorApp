using System.Windows.Input;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {

        public PictureViewModel()
        {
            Title = "Picture";

            // TODO: Set implementation of TakePictureCommand (Get from Android/iOS Projects)
            // maybe pass through constructor
        }

        public ICommand TakePictureCommand { get; }

    }
}
