using System.Text.Json.Serialization;


namespace jhPokemon.DTO.TranslationApi
{
    public class TranslationDto
    {
        [JsonPropertyName("success")]
        public TranslationSuccess Success { get; set; }

        [JsonPropertyName("contents")]
        public TranslationContents Contents { get; set; }
    }

    public class TranslationSuccess
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class TranslationContents
    {
        [JsonPropertyName("translated")]
        public string Translated { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("translation")]
        public string Translation { get; set; }
    }


}
