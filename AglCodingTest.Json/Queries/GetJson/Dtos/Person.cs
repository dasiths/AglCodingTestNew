using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AglCodingTest.Json.Queries.GetJson.Dtos
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

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (Age <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Gender))
            {
                return false;
            }

            return Pets != null && Pets.All(p => p.IsValid());
        }
    }
}
