using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AglCodingTest.Core.Domain;
using AglCodingTest.Core.ResultFilters;
using AglCodingTest.Web.Mappers.MapViewModel;
using AglCodingTest.Web.Models;

namespace AglCodingTest.Web.Queries.GetViewModel
{
    public class GetViewModelFromDomainModelQuery : IGetViewModelFromDomainModelQuery
    {
        private readonly IDomianModelToViewModelMapper _domianModelToViewModelMapper;
        private readonly List<IResultFilter<TestViewModel>> _filters;

        public GetViewModelFromDomainModelQuery(IDomianModelToViewModelMapper domianModelToViewModelMapper,
            IEnumerable<IResultFilter<TestViewModel>> filters)
        {
            _domianModelToViewModelMapper = domianModelToViewModelMapper;
            _filters = filters.ToList();
        }

        public async Task<TestViewModel[]> QueryAsync(Person[] param)
        {
            var result =  _domianModelToViewModelMapper.Map(param);

            result = _filters.Aggregate(result, (current, resultFilter) => resultFilter.GetFilteredResult(current).ToArray());

            return result
                .OrderBy(v => v.Gender.ToString())
                .ToArray();
        }
    }
}