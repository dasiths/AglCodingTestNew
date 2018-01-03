using AglCodingTest.Core.Queries.GetJson.Dtos;

namespace AglCodingTest.Core.Queries.GetJson
{
    public interface IGetAglJsonOutputQuery: IQuery<string, Person[]>
    {
    }
}