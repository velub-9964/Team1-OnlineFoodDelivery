using System.ComponentModel.DataAnnotations;

namespace DeliveryService.DTOs
{
    public class DeliveryRequestDto
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        public string DeliveryPerson { get; set; } = string.Empty;

        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;
    }
}