using System;
namespace jhPokemon.Interfaces
{
    public interface ITranslationEngine
    {
        enum TranslationTypes
        {
            Yoda,
            Shakespeare
        }

        string GetTranslation(TranslationTypes translationType, string text);
    }
}
