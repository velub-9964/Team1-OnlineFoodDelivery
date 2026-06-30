namespace PaymentService.DTOs
{
    public class PaymentResponseDto
    {
        public Guid PaymentId { get; set; }

        public Guid OrderId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? TransactionId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
