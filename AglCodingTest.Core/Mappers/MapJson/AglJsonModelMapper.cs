using AglCodingTest.Core.Queries.GetJson.Dtos;
using Newtonsoft.Json;

namespace AglCodingTest.Core.Mappers.MapJson
{
    public  class AglJsonModelMapper : IAglJsonModelMapper
    {
        public Person[] Map(string param)
        {
            return JsonConvert.DeserializeObject<Person[]>(param);
        }
    }
}