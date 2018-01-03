using System.Threading.Tasks;
using AglCodingTest.Json.Mappers.MapJson;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Queries.GetJson
{
    public class GetAglJsonOutputQuery : IGetAglJsonOutputQuery
    {
        private readonly IAglJsonModelMapper _aglJsonModelMapper;

        public GetAglJsonOutputQuery(IAglJsonModelMapper aglJsonModelMapper)
        {
            _aglJsonModelMapper = aglJsonModelMapper;
        }

        public async Task<Person[]> QueryAsync(string param)
        {
            return _aglJsonModelMapper.Map(param);
        }
    }
}
