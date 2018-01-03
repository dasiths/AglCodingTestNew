using AglCodingTest.Core.Queries;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Queries.GetJson
{
    public interface IGetAglJsonOutputQuery: IQuery<string, Person[]>
    {
    }
}