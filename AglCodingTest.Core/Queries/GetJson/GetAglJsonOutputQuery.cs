using System.Threading.Tasks;
using AglCodingTest.Core.Mappers.MapJson;
using AglCodingTest.Core.Queries.GetJson.Dtos;

namespace AglCodingTest.Core.Queries.GetJson
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
