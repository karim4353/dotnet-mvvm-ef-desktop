using Microsoft.EntityFrameworkCore;
using ENSIT.MVVMApp.Models;

namespace ENSIT.MVVMApp.Infrastructure
{
    public class ENSITContext : DbContext
    {
        public ENSITContext(DbContextOptions<ENSITContext> options) : base(options) {}
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Name);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.PlacedAt);
        }
    }
}
