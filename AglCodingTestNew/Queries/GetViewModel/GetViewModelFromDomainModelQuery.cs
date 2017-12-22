using System.Linq;
using System.Threading.Tasks;
using AglCodingTestNew.Domain;
using AglCodingTestNew.Mappers.MapViewModel;
using AglCodingTestNew.Models;
using AglCodingTestNew.ResultFilters.TestFilter;

namespace AglCodingTestNew.Queries.GetViewModel
{
    public class GetViewModelFromDomainModelQuery : IGetViewModelFromDomainModelQuery
    {
        private readonly IDomianModelToViewModelMapper _domianModelToViewModelMapper;
        private readonly ICatsFilter _catsFilter;

        public GetViewModelFromDomainModelQuery(IDomianModelToViewModelMapper domianModelToViewModelMapper, 
            ICatsFilter catsFilter)
        {
            _domianModelToViewModelMapper = domianModelToViewModelMapper;
            _catsFilter = catsFilter;
        }

        public async Task<TestViewModel[]> QueryAsync(Person[] param)
        {
            var result =  _domianModelToViewModelMapper.Map(param);

            return _catsFilter
                .GetFilteredResult(result)
                .OrderBy(v => v.Gender.ToString())
                .ToArray();
        }
    }
}