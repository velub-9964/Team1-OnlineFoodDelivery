using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "RestaurantId is required!")]
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public string IsAvailable { get; set; }
    }
}