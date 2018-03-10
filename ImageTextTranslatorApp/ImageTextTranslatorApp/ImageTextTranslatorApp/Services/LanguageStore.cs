using System;

namespace ImageTextTranslatorApp.Services
{
    public enum Language
    {
        Spanish,
        French,
        CantoneseTraditional,
        ChineseSimplified,
        ChineseTraditional,
        German,
        Italian,
        Korean,
        Russian
    };

    public class LanguageStore
    {
        private static readonly Lazy<LanguageStore> _instance = new Lazy<LanguageStore>(() => new LanguageStore());

        public static LanguageStore Instance => _instance.Value;
        
        public static Language SelectedTargetLanguage { get; private set; } = Language.Spanish;
        
        public void SetTargetLanguage(Language language)
        {
            SelectedTargetLanguage = language;
        }
    }
}
