using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Models.Commands;
using ImageTextTranslatorApp.Services;
using ImageTextTranslatorApp.ViewModel;
using System;
using System.Windows.Input;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        private Picture _picture;
        public Picture Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                DataStore.AddItemAsync(value);
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
            get { return getImageTextCommand ?? (getImageTextCommand = new GetImageTextCommand(Picture)); }
        }
        
    }
}
