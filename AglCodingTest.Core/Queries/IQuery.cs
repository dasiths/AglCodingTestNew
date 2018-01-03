using System.Threading.Tasks;

namespace AglCodingTest.Core.Queries
{
    public interface IQuery<in TInput, TOutput>
    {
        Task<TOutput> QueryAsync(TInput param);
    }
}
