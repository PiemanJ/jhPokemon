using System;
using jhPokemon.DTO.TranslationApi;
using jhPokemon.Interfaces;

namespace jhPokemon.Core
{
    public class FunTranslationEngine : ITranslationEngine
    {
        const string BaseUri = "https://api.funtranslations.com/translate/";
        const string TextParam = ".json?text=";

        public string GetTranslation(ITranslationEngine.TranslationTypes translationType, string text)
        {
            var uri = BaseUri;

            if (translationType.Equals(ITranslationEngine.TranslationTypes.Shakespeare))
                uri += "shakespeare";
            if (translationType.Equals(ITranslationEngine.TranslationTypes.Yoda))
                uri += "yoda";

            uri = string.Concat(uri, TextParam, Uri.EscapeDataString(text));

            var translation = Utils.GetFromExternalApi<TranslationDto>(uri);
            if (translation is not null)
            {
                text = translation.Contents.Translated;
            }

            return text;


        }

    }
}
