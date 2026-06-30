namespace OrderService.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public decimal Amount { get; set; }
    }
}
