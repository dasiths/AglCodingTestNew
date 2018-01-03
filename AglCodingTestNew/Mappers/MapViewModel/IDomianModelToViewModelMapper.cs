using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Mappers;
using AglCodingTestNew.Models;

namespace AglCodingTestNew.Mappers.MapViewModel
{
    public interface IDomianModelToViewModelMapper: IMapper<Person[], TestViewModel[]>
    {
    }
}
