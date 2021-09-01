using System;
using System.Linq;

using jhPokemon.DTO.PokeApi;

namespace jhPokemon
{
    public class PokeApi
    {
        public static PokemonFullDto GetPokemonFromApi(string name, bool translateDescription)
        {
            // get base detail
            var pokemonDetail = Utils.GetFromExternalApi<PokemonFullDto>(string.Concat("https://pokeapi.co/api/v2/pokemon/", name));
            if (pokemonDetail is not null && !string.IsNullOrWhiteSpace(pokemonDetail.SpeciesLink.Url))
            {
                // Get species detail
                pokemonDetail.Species = Utils.GetFromExternalApi<PokemonSpeciesDto>(pokemonDetail.SpeciesLink.Url);

                // get first "en" description
                pokemonDetail.Description = pokemonDetail.Species.FlavorTextEntries.First(p => p.Language.Name.Equals("en"))?.FlavorText;

                // clean the Description
                pokemonDetail.Description = Utils.CleanDescription(pokemonDetail.Description);

                if (translateDescription)
                {

                    if (pokemonDetail.Species.Habitat.Name.Equals("cave", StringComparison.OrdinalIgnoreCase) || pokemonDetail.Species.IsLegendary)
                    {
                        // apply Yoda translation
                        pokemonDetail.Description = Utils.TranslateText(Interfaces.ITranslationEngine.TranslationTypes.Yoda, pokemonDetail.Description);
                    }
                    else
                    {
                        // apply Shakespear translation
                        pokemonDetail.Description = Utils.TranslateText(Interfaces.ITranslationEngine.TranslationTypes.Shakespeare, pokemonDetail.Description);
                    }
                }
            }

            return pokemonDetail;
        }

        public static PokemonFullDto GetPokemonFromApi(string name)
        {
            return GetPokemonFromApi(name, false);
        }

    }
}
