using System.ComponentModel.DataAnnotations;

namespace PaymentService.DTOs
{
    public class UpdatePaymentStatusDto
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
