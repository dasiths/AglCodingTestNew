using AglCodingTestNew.Queries.GetJson.Dtos;
using Newtonsoft.Json;

namespace AglCodingTestNew.Mappers.MapJson
{
    public  class AglJsonModelMapper : IAglJsonModelMapper
    {
        public Person[] Map(string param)
        {
            return JsonConvert.DeserializeObject<Person[]>(param);
        }
    }
}