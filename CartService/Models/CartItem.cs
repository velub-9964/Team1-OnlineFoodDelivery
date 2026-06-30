namespace CartService.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }

    }
}