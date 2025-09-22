using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using ENSIT.MVVMApp.Infrastructure;
using ENSIT.MVVMApp.Models;

namespace ENSIT.MVVMApp.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public async Task InMemory_Db_CanAddAndRead()
        {
            var opts = new DbContextOptionsBuilder<ENSITContext>()
                .UseInMemoryDatabase("testdb")
                .Options;
            using var db = new ENSITContext(opts);
            db.Customers.Add(new Customer { Name = "X" });
            await db.SaveChangesAsync();
            var c = await db.Customers.FirstOrDefaultAsync();
            Assert.NotNull(c);
        }
    }
}
