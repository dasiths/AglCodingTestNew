using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Mappers;
using AglCodingTest.Web.Models;

namespace AglCodingTest.Web.Mappers.MapViewModel
{
    public interface IDomianModelToViewModelMapper: IMapper<Person[], TestViewModel[]>
    {
    }
}
