using Newtonsoft.Json;

namespace AglCodingTest.Json.Queries.GetJson.Dtos
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Type))
            {
                return false;
            }

            return true;
        }
    }
}