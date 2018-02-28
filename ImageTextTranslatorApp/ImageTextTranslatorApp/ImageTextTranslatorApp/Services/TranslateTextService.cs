using ImageTextTranslatorApp.Services.Constants;
using ImageTextTranslatorApp.Services.Keys;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImageTextTranslatorApp.Services
{
    internal class TranslateTextService
    {

        internal TranslateTextService()
        {

        }

        internal async Task<string> Translate()
        {
            string fromLanguageCode = "en";
            string toLanguageCode = "es";
            
            // var translateResponse = await TranslateRequest(string.Format(TranslateUrlTemplate, "Hello world.", "en", "fr", "general"), AzureSubscriptionKey);
            //var translateResponse = await TranslateRequest(string.Format(TranslateUrlTemplate, "Hello world.", "en", "fr", "general"), AzureSubscriptionKey);

            string translatedText;

            // TODO: Request response in Json

            try
            {
                var translateResponse = await TranslateRequest(string.Format(APIKeys.TranslatorTextUriBaseTemplate, 
                                                                                    "Hello world.", 
                                                                                    fromLanguageCode, 
                                                                                    toLanguageCode, 
                                                                                    "general"),
                                                                APIKeys.TranslatorTextServiceKey);

                string translateResponseContent = await translateResponse.Content.ReadAsStringAsync();

                if (translateResponse.IsSuccessStatusCode)
                {
                    translatedText = GetTranslatedTextFromXMLResponse(translateResponseContent);
                }
                else
                {
                    translatedText = "Unable to Translate Text";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Program has failed to translate Text", e.InnerException);
            }
            
            return await Task.FromResult(translatedText);
        }
        
        private async Task<HttpResponseMessage> TranslateRequest(string url, string azureSubscriptionKey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(AzureConstants.OcpApimSubscriptionKeyHeader, azureSubscriptionKey);
                return await client.GetAsync(url);
            }
        }

        private string GetTranslatedTextFromXMLResponse(string response)
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(response);

            return xdoc.Root.Value;
        }
        
    }
}
