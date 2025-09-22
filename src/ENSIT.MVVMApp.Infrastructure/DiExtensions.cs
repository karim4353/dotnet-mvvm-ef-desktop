using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ENSIT.MVVMApp.Services;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ENSIT.MVVMApp.Infrastructure
{
    public static class DiExtensions
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            var conn = config.GetConnectionString("Default") ?? "Data Source=data/ensit.db";
            services.AddDbContext<ENSITContext>(options => options.UseSqlite(conn));
            services.AddScoped<IDataService, EfDataService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // ensure DB created and seeded (best-effort)
            using (var sp = services.BuildServiceProvider())
            {
                try
                {
                    var db = sp.GetRequiredService<ENSITContext>();
                    db.Database.EnsureCreated();
                    DataSeeder.Seed(db);
                }
                catch
                {
                    // ignore in design-time / review scenarios
                }
            }
        }
    }
}
