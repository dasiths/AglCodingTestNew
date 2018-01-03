using AglCodingTest.Core.Mappers;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Mappers.MapJson
{
    public interface IAglJsonModelMapper: IMapper<string, Person[]>
    {
    }
}
