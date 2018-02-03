using Android.OS;
using Android.Views;
using Android.Widget;
using ImageTextTranslatorApp.ViewModels;

namespace ImageTextTranslatorApp.Droid.Fragments
{
    public class PictureFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {

        #region -- Members --

        private Button _takePictureButton;
        private ImageView _pictureImageView;

        #endregion

        #region -- Properties --

        public static PictureFragment NewInstance() => new PictureFragment { Arguments = new Bundle() };
        
        public PictureViewModel ViewModel { get; set; }

        #endregion

        #region -- Overrides --

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);  
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_take_picture, container, false);
            ViewModel = new PictureViewModel();
            _takePictureButton = view.FindViewById<Button>(Resource.Id.takePictureButton);
            _pictureImageView = view.FindViewById<ImageView>(Resource.Id.pictureImageView);
            return view;
        }
        
        public override void OnStart()
        {
            base.OnStart();
            // TODO: Add click event handler to button
            _takePictureButton.Click += takePictureButton_Click;
        }
        
        public override void OnStop()
        {
            base.OnStop();
            // TODO: Remove event handler from button
            _takePictureButton.Click -= takePictureButton_Click;
        }

        #endregion

        #region -- IBecameVisible --

        public void BecameVisible()
        {
            
        }

        #endregion

        #region -- Event Handlers --

        private void takePictureButton_Click(object sender, System.EventArgs e)
        {
            // TODO: Call take picture Command from ViewModel

            throw new System.NotImplementedException();
        }

        #endregion

    }
}