using AglCodingTest.Json.Queries.GetJson.Dtos;
using Newtonsoft.Json;

namespace AglCodingTest.Json.Mappers.MapJson
{
    public  class AglJsonModelMapper : IAglJsonModelMapper
    {
        public Person[] Map(string param)
        {
            return JsonConvert.DeserializeObject<Person[]>(param);
        }
    }
}