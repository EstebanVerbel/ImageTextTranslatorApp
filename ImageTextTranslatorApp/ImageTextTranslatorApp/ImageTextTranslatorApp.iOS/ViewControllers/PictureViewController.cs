using ImageTextTranslatorApp.ViewModels;
using System;
using UIKit;

namespace ImageTextTranslatorApp.iOS
{
    public partial class PictureViewController : UIViewController
    {
        public PictureViewModel ViewModel { get; set; }

        public PictureViewController (IntPtr handle) : base (handle)
        {
            ViewModel = new PictureViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
        }

        partial void TakePictureButton_TouchUpInside(UIButton sender)
        {
            // TODO: For now, have temp byte array of a picture here to the view model
            
            SetViewModelPictureData();

            // TODO: Display picture on a view

        }

        private void SetViewModelPictureData()
        {
            // TODO Create temp byte array with picture here

            
            ViewModel.PictureData = new byte[1];
        }





    }
}