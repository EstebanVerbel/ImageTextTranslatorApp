using Android.Graphics;
using System.IO;

namespace ImageTextTranslatorApp.Droid.Helpers
{
    internal class BitmapConverter
    {
        private Bitmap _bitmap;

        public BitmapConverter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        internal byte[] ConvertToByteArray()
        {
            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                _bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            return bitmapData;
        }
        
    }
}