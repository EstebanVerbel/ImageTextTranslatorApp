using Newtonsoft.Json;

namespace ImageTextTranslatorApp.Helpers
{
    internal class JsonDeserializer<T>
    {
        
        internal JsonDeserializer()
        {    
        }

        internal T Deserialize(string jsonResponse)
        {
            T deserializedObject = JsonConvert.DeserializeObject<T>(jsonResponse);
            return deserializedObject;
        }
        
    }
}
