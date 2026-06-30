using System.Globalization;

namespace OrderService.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public decimal Amount { get; set; }
        public String Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
