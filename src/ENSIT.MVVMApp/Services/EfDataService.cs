using ENSIT.MVVMApp.Infrastructure;
using ENSIT.MVVMApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ENSIT.MVVMApp.Services
{
    public class EfDataService : IDataService
    {
        private readonly ENSITContext _db;
        private readonly ILogger _logger = Log.ForContext<EfDataService>();

        public EfDataService(ENSITContext db) { _db = db; }

        public async Task<IReadOnlyList<Customer>> SearchCustomersAsync(string q, CancellationToken token = default)
        {
            var sw = Stopwatch.StartNew();
            IQueryable<Customer> query = _db.Customers.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(c => c.Name!.Contains(q) || (c.Email != null && c.Email.Contains(q)));
            }
            var list = await query.OrderBy(c => c.Name).Take(100).ToListAsync(token);
            sw.Stop();
            _logger.Information("Query duration {ElapsedMs}ms (Search='{Search}')", sw.ElapsedMilliseconds, q);
            return list;
        }

        public Task<string> RunPerfSampleAsync()
        {
            // small sample: compiled query + timing
            var compiled = EF.CompileQuery((ENSITContext ctx, string name) =>
                ctx.Customers.Where(c => c.Name!.StartsWith(name)).AsNoTracking().OrderBy(c => c.Id).Take(50));

            var sw = new Stopwatch();
            sw.Start();
            var res = compiled(_db, "A").ToList();
            sw.Stop();
            return Task.FromResult($"Compiled query returned {res.Count} rows in {sw.ElapsedMilliseconds}ms");
        }
    }
}
