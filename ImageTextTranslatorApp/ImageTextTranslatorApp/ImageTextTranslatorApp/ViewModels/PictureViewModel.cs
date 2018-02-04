using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Models.Services;
using System.Windows.Input;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        
        private ITakePicture _takePicture => ServiceLocator.Instance.Get<ITakePicture>();

        public PictureViewModel()
        {
            Title = "Picture";

            // TODO: Set implementation of TakePictureCommand (Get from Android/iOS Projects)
            // maybe pass through constructor
            //_takePicture = ServiceLocator.Get<ITakePicture>();
            
            TakePictureCommand = new Command(_takePicture.TakeAPicture());

        }

        public ICommand TakePictureCommand { get; }

    }
}
