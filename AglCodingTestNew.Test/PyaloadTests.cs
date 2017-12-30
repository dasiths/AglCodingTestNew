using System;
using System.IO;
using System.Threading.Tasks;
using AglCodingTestNew.Mappers.MapDomain;
using AglCodingTestNew.Mappers.MapJson;
using AglCodingTestNew.Queries.GetJson;
using Xunit;

namespace AglCodingTestNew.Test
{
    public class PyaloadTests
    {
        [Fact]
        public async Task CorrectPayloadSizeIsRetreived()
        {
            var payload = File.ReadAllText("sample.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Equal(6, result.Length);
        }
    }
}
