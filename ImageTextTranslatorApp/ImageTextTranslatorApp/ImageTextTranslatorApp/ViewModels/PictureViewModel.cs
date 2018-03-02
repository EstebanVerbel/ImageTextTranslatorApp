using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Models.Commands;
using ImageTextTranslatorApp.ViewModel;
using System.Windows.Input;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        private Picture _picture;
        private Picture Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                DataStore.AddItemAsync(value);
            }
        }

        public byte[] PictureData
        {
            get { return Picture.PictureData; }
            set
            {
                Picture = new Picture();
                Picture.PictureData = value;
            }
        }
        
        public string Text
        {
            get { return Picture.Text; }
            set
            {
                if (Picture != null)
                    Picture.Text = value;
            }
        }
        
        public PictureViewModel()
        {
            Title = "Picture";
        }
        
        private ICommand getImageTextCommand;
        /// <summary>
        /// ICommand Gets Text From Image
        /// </summary>
        public ICommand GetTextCommand
        {
            get { return  (getImageTextCommand = new GetImageTextCommand(Picture)); }
        }
        
    }
}
