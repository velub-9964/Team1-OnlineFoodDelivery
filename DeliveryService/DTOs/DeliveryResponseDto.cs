namespace DeliveryService.DTOs
{
    public class DeliveryResponseDto
    {
        public Guid DeliveryId { get; set; }

        public Guid OrderId { get; set; }

        public Guid PaymentId { get; set; }

        public string DeliveryPerson { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;

        public string DeliveryStatus { get; set; } = string.Empty;

        public DateTime EstimatedDeliveryTime { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}