using System.Threading.Tasks;
using AglCodingTest.Core.Mappers.MapDomain;
using AglCodingTest.Core.Queries.GetJson.Dtos;

namespace AglCodingTest.Core.Queries.GetDomainModel
{
    public class GetDomainModelsFromDtosQuery : IGetDomainModelsFromDtosQuery
    {
        private readonly IJsonDtoToDomainMapper _jsonDtoToDomainMapper;

        public GetDomainModelsFromDtosQuery(IJsonDtoToDomainMapper jsonDtoToDomainMapper)
        {
            _jsonDtoToDomainMapper = jsonDtoToDomainMapper;
        }

        public async Task<Domain.Person[]> QueryAsync(Person[] param)
        {
            return _jsonDtoToDomainMapper.Map(param);
        }
    }
}