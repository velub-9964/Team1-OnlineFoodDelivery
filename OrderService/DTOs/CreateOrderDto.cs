using System.ComponentModel.DataAnnotations;

namespace OrderService.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RestaurantId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
