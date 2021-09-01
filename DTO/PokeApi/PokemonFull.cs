using System.Text.Json.Serialization;


namespace jhPokemon.DTO.PokeApi
{
    public class PokemonFullDto
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }


        [JsonPropertyName("species")]
        public PokemonGenericLinkDto SpeciesLink { get; set; }

        public PokemonSpeciesDto Species { get; set; }

        public string Description { get; set; }

    }
}
