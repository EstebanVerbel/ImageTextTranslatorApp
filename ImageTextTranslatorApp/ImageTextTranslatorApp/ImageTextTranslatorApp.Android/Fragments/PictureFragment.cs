using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace ImageTextTranslatorApp.Droid
{
    public class PictureFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        private Button _takePictureButton;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate Picture Fragment
            var view = inflater.Inflate(Resource.Layout.fragment_picture, container, false);

            _takePictureButton = view.FindViewById<Button>(Resource.Id.takePictureButton);

            return view;
        }

        


        public void BecameVisible()
        {
            throw new NotImplementedException();
        }
    }
}