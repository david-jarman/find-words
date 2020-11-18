using Newtonsoft.Json;

namespace SpellingBee.Controllers
{
    [JsonObject]
    public class FindWordsBody
    {
        [JsonProperty("possibleLetters")]
        public string PossibleLetters { get; set; }

        [JsonProperty("mustIncludeLetter")]
        public char MustIncludeLetter { get; set; }
    }
}