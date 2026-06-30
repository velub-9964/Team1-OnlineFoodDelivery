using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Restaurant Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public bool IsOpen { get; set; }
    }
}