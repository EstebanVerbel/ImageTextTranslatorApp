using ImageTextTranslatorApp.Helpers;
using ImageTextTranslatorApp.Models;
using ImageTextTranslatorApp.Services.Constants;
using ImageTextTranslatorApp.Services.Keys;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ImageTextTranslatorApp.Services
{
    internal class ComputerVisionService
    {
        private byte[] _pictureData;

        internal ComputerVisionService(byte[] pictureData)
        {
            _pictureData = pictureData;
        }
        
        internal async Task<string> GetImageTextAsync()
        {
            string responseText = "";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(AzureConstants.OcpApimSubscriptionKeyHeader, APIKeys.ComputerVisionServiceKey);
                
                // Request parameter. Set "handwriting" to false for printed text.
                //string requestParameters = "handwriting=true";
                //string requestParameters = "visualFeatures=Categories,Description,Color&language=en";
                string requestParameters = "language=unk&detectOrientation=true";
                
                HttpResponseMessage response = null;

                // This operation requrires two REST API calls. One to submit the image for processing,
                // the other to retrieve the text found in the image. This value stores the REST API
                // location to call to retrieve the text.
                string operationLocation = null;
                
                try
                {
                    // Assemble the URI for the REST API Call.
                    string uri = $"{APIKeys.ComputerVisionUriBase}?{requestParameters}";
                    response = await SubmitImageToServicePost(uri, client);

                    // The response contains the URI to retrieve the result of the process.
                    if (response.IsSuccessStatusCode)
                    {
                        operationLocation = response.Headers.GetValues("Operation-Location").FirstOrDefault();
                    }
                    else
                    {
                        responseText = "Unable to read text from image";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Program has failed to translate Text", e.InnerException);
                }
                
                if (responseText == "")
                {
                    string contentString = "";

                    try
                    {
                        contentString = await RetrieveTextFromImageGet(client, operationLocation);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Program has failed to translate Text", e.InnerException);
                    }
                    
                    if (contentString.IndexOf("\"status\":\"Succeeded\"") == -1)
                    {
                        responseText = "Unable to read text from image";
                    }
                    else
                    {
                        // deserialize response
                        responseText = DeserializeResponse(contentString);
                    }
                }
            }
            
            return responseText.Trim();
        }
        
        private async Task<string> RetrieveTextFromImageGet(HttpClient client, string requestUri)
        {
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
                var response = await client.GetAsync(requestUri);
                contentString = await response.Content.ReadAsStringAsync();
                ++i;
            }
            while
            (i < 10
                &&
            contentString.IndexOf("\"status\":\"Succeeded\"") == -1);
            
            return contentString;
        }
        
        private async Task<HttpResponseMessage> SubmitImageToServicePost(string uri, HttpClient client)
        {
            // Request headers.
            client.DefaultRequestHeaders.Add(AzureConstants.OcpApimSubscriptionKeyHeader, APIKeys.ComputerVisionServiceKey);

            // Request body. Posts a locally stored JPEG image.
            ByteArrayContent content = new ByteArrayContent(_pictureData);

            // Using content type "application/octet-stream".
            // But can also use "application/json" and specify an image URL.
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return await client.PostAsync(uri, content);
        }

        private string DeserializeResponse(string contentString)
        {
            // deserialize response 
            JsonDeserializer<TextInImageResponse> deserializer = new JsonDeserializer<TextInImageResponse>();
            var responseJsonObject = deserializer.Deserialize(contentString);

            string responseText = "";

            foreach (var line in responseJsonObject.recognitionResult.lines)
            {
                responseText += $"{line.text}{System.Environment.NewLine}";
            }

            return responseText;
        }
   
    }
    
}
