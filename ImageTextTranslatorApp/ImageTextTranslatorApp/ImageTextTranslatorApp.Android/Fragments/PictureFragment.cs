using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Views;
using Android.Widget;
using ImageTextTranslatorApp.Droid.Helpers;
using ImageTextTranslatorApp.ViewModels;
using System;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.Droid
{
    public class PictureFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        #region -- Properties --

        public static PictureFragment NewInstance() => new PictureFragment { Arguments = new Bundle() };

        public PictureViewModel ViewModel { get; set; }

        #endregion

        #region -- Members --

        private Button _takePictureButton;
        private ImageView _pictureImageView;

        #endregion

        #region -- Overrides --

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate Picture Fragment
            var view = inflater.Inflate(Resource.Layout.fragment_picture, container, false);
            ViewModel = new PictureViewModel();
            _takePictureButton = view.FindViewById<Button>(Resource.Id.takePictureButton);
            _pictureImageView = view.FindViewById<ImageView>(Resource.Id.pictureImageView);
            
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            _takePictureButton.Click += takePictureButton_Click;
        }
        
        public override void OnStop()
        {
            base.OnStop();
            _takePictureButton.Click -= takePictureButton_Click;
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            _pictureImageView.SetImageBitmap(bitmap);

            if (bitmap != null)
            {
                SetViewModelPictureData(bitmap);
                ViewModel.GetTextCommand.Execute(null);
            }
            // else
            // TODO: Display message to user saying something went wrong
   
        }

        #endregion

        #region -- Event Handlers --

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
        
        #endregion

        #region -- Private Methods --

        private void SetViewModelPictureData(Bitmap bitmap)
        {
            ViewModel.PictureData = ConvertBitmapToByteArray(bitmap);
        }

        private byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            BitmapConverter converter = new BitmapConverter(bitmap);
            return converter.ConvertToByteArray();
        }

        #endregion

        #region -- Interfaces --
        
        public async Task BecameVisibleAsync()
        {
        }

        #endregion

    }
}