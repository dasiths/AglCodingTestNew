using System.Threading.Tasks;
using AglCodingTest.Core.Queries.GetHttpQuery;
using Xunit;

namespace AglCodingTest.Core.Tests
{
    public class QueryTests
    {
        [Fact]
        public async Task HttpResourceIsRetreived()
        {
            var query = new GetHttpResourceQuery();
            var result = await query.QueryAsync(@"http://agl-developer-test.azurewebsites.net/people.json");

            Assert.True(result.Length > 0);
        }
    }
}
