using System.Collections;
using System.Collections.Generic;

namespace AglCodingTestNew.ResultFilters
{
    public interface IResultFilter<T>
    {
        IEnumerable<T> GetFilteredResult(IEnumerable<T> input);
    }
}
