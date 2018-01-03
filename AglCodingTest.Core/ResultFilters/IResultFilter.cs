using System.Collections.Generic;

namespace AglCodingTest.Core.ResultFilters
{
    public interface IResultFilter<T>
    {
        IEnumerable<T> GetFilteredResult(IEnumerable<T> input);
    }
}
