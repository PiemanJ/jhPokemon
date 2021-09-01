using System.Text.Json.Serialization;

/*
    Any transfer of data with external systems should be done using a Data Transfer Object.

    For internal processing, these should be mapped to internal Models
  
 */


namespace jhPokemon.DTO.PokeApi
{

    public class PokemonSpeciesDto
    {
        [JsonPropertyName("base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonPropertyName("capture_rate")]
        public int CaptureRate { get; set; }

        [JsonPropertyName("generation")]
        public PokemonGenericLinkDto Generation { get; set; }

        [JsonPropertyName("growth_rate")]
        public PokemonGenericLinkDto GrowthRate { get; set; }

        [JsonPropertyName("habitat")]
        public PokemonGenericLinkDto Habitat { get; set; }

        [JsonPropertyName("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public FlavorTextEntriesDto[] FlavorTextEntries { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }
    }


    public class FlavorTextEntriesDto
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        [JsonPropertyName("language")]
        public PokemonGenericLinkDto Language { get; set; }

        [JsonPropertyName("version")]
        public PokemonGenericLinkDto Version { get; set; }
    }

}
