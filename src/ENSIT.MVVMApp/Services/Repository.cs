using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ENSIT.MVVMApp.Infrastructure;

namespace ENSIT.MVVMApp.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ENSITContext _db;
        public Repository(ENSITContext db) => _db = db;
        public async Task AddAsync(T entity, CancellationToken token = default) { _db.Add(entity); await Task.CompletedTask; }
        public async Task<T?> GetAsync(object id, CancellationToken token = default) => await _db.FindAsync(new object[] { id }, token) as T;
        public async Task<IReadOnlyList<T>> ListAsync(CancellationToken token = default) => await _db.Set<T>().AsNoTracking().ToListAsync(token);
        public async Task SaveChangesAsync(CancellationToken token = default) => await _db.SaveChangesAsync(token);
    }
}
