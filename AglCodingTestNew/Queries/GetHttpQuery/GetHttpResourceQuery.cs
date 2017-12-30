using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AglCodingTestNew.Exceptions;

namespace AglCodingTestNew.Queries.GetHttpQuery
{
    public class GetHttpResourceQuery : IGetHttpResourceQuery
    {
        public async Task<string> QueryAsync(string param)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(param);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }

            throw new ExternalResourceNotAvailableException(param, $"StatusCode = {response.StatusCode.ToString()}");

        }
    }
}