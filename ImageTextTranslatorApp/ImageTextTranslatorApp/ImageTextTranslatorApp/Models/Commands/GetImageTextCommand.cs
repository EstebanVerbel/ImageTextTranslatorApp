using ImageTextTranslatorApp.Services;
using System;
using System.Windows.Input;

namespace ImageTextTranslatorApp.Models.Commands
{
    public class GetImageTextCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Picture _picture;

        public GetImageTextCommand(Picture picture)
        {
            _picture = picture;
        }

        public bool CanExecute(object parameter)
        {
            // TODO: Only if device is connected to internet
            return true;
        }

        /// <summary>
        /// Excecutes the Computer Vision Service to get text from Image
        /// </summary>
        /// <param name="parameter">Picture</param>
        public async void Execute(object parameter)
        {
            ComputerVisionService computerVisionService = new Services.ComputerVisionService(_picture.PictureData);
            string text = await computerVisionService.GetImageTextAsync();
            _picture.Text = text;
        }
    }
}
