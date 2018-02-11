﻿using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.Services
{
    internal class ComputerVisionService
    {

        private const string _subscriptionsKey = "";
        
        // const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/recognizeText";
        private const string _uriBase = "https://westus.api.cognitive.microsoft.com/vision/v1.0/recognizeText";

        private byte[] _pictureData;

        internal ComputerVisionService(byte[] pictureData)
        {
            _pictureData = pictureData;
        }

        internal async Task<string> GetImageTextAsync()
        {
            HttpClient httpClient = new HttpClient();
            
            // Request headers.
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionsKey);
            
            // Request parameter. Set "handwriting" to false for printed text.
            string requestParameters = "handwriting=true";
            
            // Assemble the URI for the REST API Call.
            string uri = $"{_uriBase}?{requestParameters}";
            
            HttpResponseMessage response = null;

            // This operation requrires two REST API calls. One to submit the image for processing,
            // the other to retrieve the text found in the image. This value stores the REST API
            // location to call to retrieve the text.
            string operationLocation = null;

            // Request body. Posts a locally stored JPEG image.
            ByteArrayContent content = new ByteArrayContent(_pictureData);

            // This example uses content type "application/octet-stream".
            // You can also use "application/json" and specify an image URL.
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // The first REST call starts the async process to analyze the written text in the image.
            response = await httpClient.PostAsync(uri, content);

            // The response contains the URI to retrieve the result of the process.
            if (response.IsSuccessStatusCode)
            {
                operationLocation = response.Headers.GetValues("Operation-Location").FirstOrDefault();
            }
            else
            {
                // error
            }

            // The second REST call retrieves the text written in the image.
            //
            // Note: The response may not be immediately available. Handwriting recognition is an
            // async operation that can take a variable amount of time depending on the length
            // of the handwritten text. You may need to wait or retry this operation.
            //
            // Checks once per second for ten seconds.
            string contentString;
            int i = 0;

            do
            {
                Task.Delay(1000).Wait();
                response = await httpClient.GetAsync(operationLocation);
                contentString = await response.Content.ReadAsStringAsync();
                ++i;
            }
            while 
            (i < 10 
                && 
            contentString.IndexOf("\"status\":\"Succeeded\"") == -1);
            
            if (i == 10 && contentString.IndexOf("\"status\":\"Succeeded\"") == -1)
            {
                // time out error
            }

            //// Display the JSON response.
            //Console.WriteLine("\nResponse:\n");
            //Console.WriteLine(JsonPrettyPrint(contentString));

            return "";
        }

    }
}
