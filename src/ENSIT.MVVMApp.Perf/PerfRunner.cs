using System;
using ENSIT.MVVMApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics;

namespace ENSIT.MVVMApp.Perf
{
    class Program
    {
        static void Main()
        {
            var options = new DbContextOptionsBuilder<ENSITContext>()
                .UseSqlite("Data Source=data/ensit.db")
                .Options;
            using var db = new ENSITContext(options);
            // simple warmup
            db.Database.EnsureCreated();
            var sw = Stopwatch.StartNew();
            var count = db.Customers.AsNoTracking().Count();
            sw.Stop();
            Console.WriteLine($"Customers: {count} (count took {sw.ElapsedMilliseconds}ms)");
            // compiled query example
            var compiled = EF.CompileQuery((ENSITContext ctx) => ctx.Customers.AsNoTracking().Where(c => c.Name!.StartsWith("Customer")));
            sw.Restart();
            var r = compiled(db).Take(10).ToList();
            sw.Stop();
            Console.WriteLine($"Compiled query returned {r.Count} rows in {sw.ElapsedMilliseconds}ms");
        }
    }
}
