using System;
using System.Linq;
using ENSIT.MVVMApp.Models;

namespace ENSIT.MVVMApp.Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(ENSITContext db)
        {
            if (db.Customers.Any()) return;
            var customers = Enumerable.Range(1, 40).Select(i => new Customer {
                Name = $"Customer {i}",
                Email = $"customer{i}@example.com"
            }).ToList();
            db.AddRange(customers);
            db.SaveChanges();
            // add some orders
            var rnd = new Random(0);
            foreach (var c in db.Customers.ToList())
            {
                db.Orders.Add(new Order { CustomerId = c.Id, PlacedAt = DateTime.UtcNow.AddDays(-rnd.Next(0, 100)), Total = rnd.Next(20,500) });
            }
            db.SaveChanges();
        }
    }
}
