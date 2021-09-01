using System.Linq;


namespace jhPokemon
{
    public class Mapper
    {
        public static DTO.PokemonBasicDto Map(DTO.PokeApi.PokemonFullDto inObj)
        {
            DTO.PokemonBasicDto result = null;

            if (inObj is not null)
            {
                result = new();
                result.Name = inObj.Name;

                if (inObj.Species is not null)
                {
                    result.Habitat = inObj.Species?.Habitat?.Name;
                    result.IsLegendary = inObj.Species.IsLegendary;
                    result.Description = inObj.Description;

                    if (string.IsNullOrWhiteSpace(result.Description))
                    {
                        // for description, get the first "en" entry
                        result.Description = Utils.CleanDescription(inObj.Species.FlavorTextEntries.First(p => p.Language.Name.Equals("en")).FlavorText);
                    }
                }
            }

            return result;
        }
    }
}
