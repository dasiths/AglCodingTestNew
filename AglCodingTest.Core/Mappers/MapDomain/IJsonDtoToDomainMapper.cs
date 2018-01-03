using AglCodingTest.Core.Queries.GetJson.Dtos;

namespace AglCodingTest.Core.Mappers.MapDomain
{
    public interface IJsonDtoToDomainMapper: IMapper<Person[], Domain.Person[]>
    {
    }
}
