using System;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Customer;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // public Customer? Customer { get; set; }
    }
}