using System.Collections.Generic;
using Newtonsoft.Json;

namespace AglCodingTest.Core.Queries.GetJson.Dtos
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }
}
