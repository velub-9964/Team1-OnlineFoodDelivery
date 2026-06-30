using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}