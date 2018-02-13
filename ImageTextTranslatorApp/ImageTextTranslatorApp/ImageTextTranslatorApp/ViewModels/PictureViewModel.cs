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
        public Picture Picture { get; set; }
        
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
