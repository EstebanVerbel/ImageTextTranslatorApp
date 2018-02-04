using System;
using System.Collections.Generic;
using System.Text;

namespace ImageTextTranslatorApp.Models.Services
{
    public interface ITakePicture
    {
        Action TakeAPicture();

        void GetPicture();

        bool CanTakePicture();

    }
}
