using ImageTextTranslatorApp.Services.Constants;
using ImageTextTranslatorApp.Services.Keys;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
                    translatedText = translateResponseContent;
                }
                else
                {
                    translatedText = "Unable to Translate Text";
                }
            }
            catch (Exception)
            {
                throw;
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
        
    }
}
