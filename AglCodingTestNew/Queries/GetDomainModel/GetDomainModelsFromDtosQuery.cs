using System.Threading.Tasks;
using AglCodingTestNew.Mappers.MapDomain;
using AglCodingTestNew.Queries.GetJson.Dtos;

namespace AglCodingTestNew.Queries.GetDomainModel
{
    class GetDomainModelsFromDtosQuery : IGetDomainModelsFromDtosQuery
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