using AglCodingTestNew.Queries.GetJson.Dtos;

namespace AglCodingTestNew.Queries.GetJson
{
    public interface IGetAglJsonOutputQuery: IQuery<string, Person[]>
    {
    }
}