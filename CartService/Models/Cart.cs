namespace CartService.Models
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
