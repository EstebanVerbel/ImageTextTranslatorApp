using System.Collections.Generic;

namespace ImageTextTranslatorApp.Services.Constants
{
    internal class LanguageConstants
    {
        private Dictionary<Language, string> _languagesDictionary;

        internal LanguageConstants()
        {
            InitializeLanguages();
        }

        private void InitializeLanguages()
        {
            _languagesDictionary = new Dictionary<Language, string>();
            
            // add all languages to dictionary
            _languagesDictionary.Add(Language.Spanish, "es");
            _languagesDictionary.Add(Language.French, "fr");
            _languagesDictionary.Add(Language.CantoneseTraditional, "yue");
            _languagesDictionary.Add(Language.ChineseSimplified, "zh-Hans");
            _languagesDictionary.Add(Language.ChineseTraditional, "zh-Hant");
            _languagesDictionary.Add(Language.German, "de");
            _languagesDictionary.Add(Language.Italian, "it");
            _languagesDictionary.Add(Language.Korean, "ko");
            _languagesDictionary.Add(Language.Russian, "ru");
        }

        internal string GetSelectedTargetLanguage()
        {
            Language selectedTargetLanguage = LanguageStore.Instance.SelectedTargetLanguage;
            return _languagesDictionary[selectedTargetLanguage];
        }
        
    }
}
