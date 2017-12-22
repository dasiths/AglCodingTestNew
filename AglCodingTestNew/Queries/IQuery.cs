using System.Threading.Tasks;

namespace AglCodingTestNew.Queries
{
    public interface IQuery<in TInput, TOutput>
    {
        Task<TOutput> QueryAsync(TInput param);
    }
}
