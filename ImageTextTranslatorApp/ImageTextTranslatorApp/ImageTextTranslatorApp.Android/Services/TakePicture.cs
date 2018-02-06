using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImageTextTranslatorApp.Models.Services;

namespace ImageTextTranslatorApp.Droid
{
    public class TakePicture : Android.Support.V4.App.Fragment, ITakePicture
    {

        public TakePicture()
        {
        }

        public Action TakeAPicture()
        {
            Action takePictureDel = delegate() 
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            return takePictureDel;
        }
        
        public void GetPicture()
        {
            throw new NotImplementedException();
        }

        public bool CanTakePicture()
        {
            throw new NotImplementedException();
        }

    }
}