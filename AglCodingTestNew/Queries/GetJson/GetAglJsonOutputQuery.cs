using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AglCodingTestNew.Exceptions;
using AglCodingTestNew.Mappers.MapJson;
using AglCodingTestNew.Queries.GetJson.Dtos;

namespace AglCodingTestNew.Queries.GetJson
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
