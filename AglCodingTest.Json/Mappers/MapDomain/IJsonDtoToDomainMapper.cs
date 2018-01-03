using AglCodingTest.Core.Mappers;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Mappers.MapDomain
{
    public interface IJsonDtoToDomainMapper: IMapper<Person[], Core.Domain.Person[]>
    {
    }
}
