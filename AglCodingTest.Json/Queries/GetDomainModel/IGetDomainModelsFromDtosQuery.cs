using AglCodingTest.Core.Queries;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Queries.GetDomainModel
{
    public interface IGetDomainModelsFromDtosQuery: IQuery<Person[], Core.Domain.Person[]>
    {
    }
}
