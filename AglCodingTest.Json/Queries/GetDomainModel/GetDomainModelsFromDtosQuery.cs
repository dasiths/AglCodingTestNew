using System.Threading.Tasks;
using AglCodingTest.Json.Mappers.MapDomain;
using AglCodingTest.Json.Queries.GetJson.Dtos;

namespace AglCodingTest.Json.Queries.GetDomainModel
{
    public class GetDomainModelsFromDtosQuery : IGetDomainModelsFromDtosQuery
    {
        private readonly IJsonDtoToDomainMapper _jsonDtoToDomainMapper;

        public GetDomainModelsFromDtosQuery(IJsonDtoToDomainMapper jsonDtoToDomainMapper)
        {
            _jsonDtoToDomainMapper = jsonDtoToDomainMapper;
        }

        public async Task<Core.Domain.Person[]> QueryAsync(Person[] param)
        {
            return _jsonDtoToDomainMapper.Map(param);
        }
    }
}