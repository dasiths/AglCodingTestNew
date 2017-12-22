using Newtonsoft.Json;

namespace AglCodingTestNew.Queries.GetJson.Dtos
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}