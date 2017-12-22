using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AglCodingTestNew.Exceptions;
using AglCodingTestNew.Mappers.MapJson;
using AglCodingTestNew.Queries.GetJson.Dtos;

namespace AglCodingTestNew.Queries.GetJson
{
    public class GetAglJsonOutputQuery: IGetAglJsonOutputQuery
    {
        private readonly IAglJsonModelMapper _aglJsonModelMapper;

        public GetAglJsonOutputQuery(IAglJsonModelMapper aglJsonModelMapper)
        {
            _aglJsonModelMapper = aglJsonModelMapper;
        }
        
        public async Task<Person[]> QueryAsync(string param)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(param);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return _aglJsonModelMapper.Map(body);
            }

            throw new ExternalResourceNotAvailableException(param, $"StatusCode = {response.StatusCode.ToString()}");
        }
    }
}
