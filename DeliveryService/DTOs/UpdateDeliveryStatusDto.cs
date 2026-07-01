using System.ComponentModel.DataAnnotations;

namespace DeliveryService.DTOs
{
    public class UpdateDeliveryStatusDto
    {
        [Required]
        public string DeliveryStatus { get; set; } = string.Empty;
    }
}