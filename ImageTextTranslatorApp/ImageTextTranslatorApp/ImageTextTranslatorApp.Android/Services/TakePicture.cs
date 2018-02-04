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

namespace ImageTextTranslatorApp.Droid.Services
{
    public class TakePicture : Android.Support.V4.App.Fragment, ITakePicture
    {
        public void GetPicture()
        {
            throw new NotImplementedException();
        }

        public void TakeAPicture()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
    }
}