using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Services;
using ImageTextTranslatorApp.ViewModel;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        public Picture Picture { get; set; }

        public PictureViewModel()
        {
            Title = "Picture";
        }




        // temp method (test)
        public async void ReadTextFromImageAsync()
        {
            ComputerVisionService computerVisionService = new Services.ComputerVisionService(Picture.PictureData);
            string text = await computerVisionService.GetImageTextAsync();
        }


    }
}
