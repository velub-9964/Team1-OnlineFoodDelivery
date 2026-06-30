namespace CartService.DTOs
{
    public class AddCartItemDto
    {

        public int CustomerId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
