using System.ComponentModel.DataAnnotations;

namespace ENSIT.MVVMApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
