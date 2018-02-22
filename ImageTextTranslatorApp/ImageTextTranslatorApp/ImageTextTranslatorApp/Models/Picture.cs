using ImageTextTranslatorApp.Model;

namespace ImageTextTranslatorApp.Models
{
    public class Picture : BaseDataObject
    {
        public Picture()
            : base()
        {
        }
        
        public byte[] PictureData { get; set; }
        
        private string _text;
        public string Text
        { 
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
