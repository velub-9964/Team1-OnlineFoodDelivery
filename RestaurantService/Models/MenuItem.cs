using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Restaurant ID is required")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Menu Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 5000, ErrorMessage = "Price must be between 1 and 5000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
    }
}