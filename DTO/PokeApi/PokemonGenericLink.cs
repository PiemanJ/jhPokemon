using System.Text.Json.Serialization;


namespace jhPokemon.DTO.PokeApi
{
    public class PokemonGenericLinkDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("url")]
        public string Url { get; set; }


    }

}
