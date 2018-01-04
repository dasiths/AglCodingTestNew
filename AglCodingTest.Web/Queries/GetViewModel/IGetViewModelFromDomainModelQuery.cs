using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Queries;
using AglCodingTest.Web.Models;

namespace AglCodingTest.Web.Queries.GetViewModel
{
    public interface IGetViewModelFromDomainModelQuery: IQuery<Person[], TestViewModel[]>
    {
    }
}
