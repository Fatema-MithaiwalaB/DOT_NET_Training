using System.ComponentModel.DataAnnotations;

namespace EF_Assignment_3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
