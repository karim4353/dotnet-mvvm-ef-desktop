using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ENSIT.MVVMApp.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> ListAsync(CancellationToken token = default);
        Task<T?> GetAsync(object id, CancellationToken token = default);
        Task AddAsync(T entity, CancellationToken token = default);
        Task SaveChangesAsync(CancellationToken token = default);
    }
}
