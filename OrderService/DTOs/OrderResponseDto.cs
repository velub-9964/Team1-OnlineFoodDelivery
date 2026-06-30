namespace OrderService.DTOs
{
    public class OrderResponseDto
    {
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public decimal Amount { get; set; }
        public String Status { get; set; }

        public DateTime CreatedAt { get; set;
    }
}}
