namespace ImageTextTranslatorApp.Models
{
    /// <summary>
    /// Format of Json Response for Text in Image Cognitive Service
    /// </summary>
    internal class TextInImageResponse
    {
        public string status { get; set; }

        public RecognitionResult recognitionResult { get; set; }
    }

    internal class RecognitionResult
    {
        public Lines[] lines { get; set; }   
    }

    internal class Lines
    {
        public int[] boundingBox { get; set; }

        public string text { get; set; }
    }

}
