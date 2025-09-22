using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENSIT.MVVMApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
