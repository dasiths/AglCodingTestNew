using AglCodingTestNew.Domain;
using AglCodingTestNew.Models;

namespace AglCodingTestNew.Mappers.MapViewModel
{
    public interface IDomianModelToViewModelMapper: IMapper<Person[], TestViewModel[]>
    {
    }
}
