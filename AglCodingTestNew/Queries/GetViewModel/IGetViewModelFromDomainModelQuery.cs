using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Queries;
using AglCodingTestNew.Models;

namespace AglCodingTestNew.Queries.GetViewModel
{
    public interface IGetViewModelFromDomainModelQuery: IQuery<Person[], TestViewModel[]>
    {
    }
}
