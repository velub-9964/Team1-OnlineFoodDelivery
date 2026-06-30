using System.ComponentModel.DataAnnotations;

namespace PaymentService.DTOs
{
    public class PaymentRequestDto
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
