using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Models
{
    public class Delivery
    {
        [Key]
        public Guid DeliveryId { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DeliveryPerson { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string DeliveryStatus { get; set; } = "Pending";

        public DateTime EstimatedDeliveryTime { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}