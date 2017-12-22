using AglCodingTestNew.Domain;
using AglCodingTestNew.Models;

namespace AglCodingTestNew.Queries.GetViewModel
{
    public interface IGetViewModelFromDomainModelQuery: IQuery<Person[], TestViewModel[]>
    {
    }
}
