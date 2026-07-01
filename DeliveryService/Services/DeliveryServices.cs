using DeliveryService.DTOs;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Services
{
    public class DeliveryServices: IDeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryServices(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryResponseDto> CreateDeliveryAsync(DeliveryRequestDto request)
        {
            var delivery = new Delivery
            {
                DeliveryId = Guid.NewGuid(),
                OrderId = request.OrderId,
                PaymentId = request.PaymentId,
                DeliveryPerson = request.DeliveryPerson,
                DeliveryAddress = request.DeliveryAddress,
                DeliveryStatus = "Pending",
                EstimatedDeliveryTime = DateTime.UtcNow.AddMinutes(45)
            };

            await _repository.CreateDeliveryAsync(delivery);

            return new DeliveryResponseDto
            {
                DeliveryId = delivery.DeliveryId,
                OrderId = delivery.OrderId,
                PaymentId = delivery.PaymentId,
                DeliveryPerson = delivery.DeliveryPerson,
                DeliveryAddress = delivery.DeliveryAddress,
                DeliveryStatus = delivery.DeliveryStatus,
                EstimatedDeliveryTime = delivery.EstimatedDeliveryTime,
                DeliveredAt = delivery.DeliveredAt
            };
        }

        public async Task<IEnumerable<DeliveryResponseDto>> GetAllDeliveriesAsync()
        {
            var deliveries = await _repository.GetAllDeliveriesAsync();

            return deliveries.Select(delivery => new DeliveryResponseDto
            {
                DeliveryId = delivery.DeliveryId,
                OrderId = delivery.OrderId,
                PaymentId = delivery.PaymentId,
                DeliveryPerson = delivery.DeliveryPerson,
                DeliveryAddress = delivery.DeliveryAddress,
                DeliveryStatus = delivery.DeliveryStatus,
                EstimatedDeliveryTime = delivery.EstimatedDeliveryTime,
                DeliveredAt = delivery.DeliveredAt
            });
        }

        public async Task<DeliveryResponseDto?> GetDeliveryByIdAsync(Guid deliveryId)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(deliveryId);

            if (delivery == null)
                return null;

            return new DeliveryResponseDto
            {
                DeliveryId = delivery.DeliveryId,
                OrderId = delivery.OrderId,
                PaymentId = delivery.PaymentId,
                DeliveryPerson = delivery.DeliveryPerson,
                DeliveryAddress = delivery.DeliveryAddress,
                DeliveryStatus = delivery.DeliveryStatus,
                EstimatedDeliveryTime = delivery.EstimatedDeliveryTime,
                DeliveredAt = delivery.DeliveredAt
            };
        }

        public async Task UpdateDeliveryStatusAsync(Guid deliveryId, UpdateDeliveryStatusDto request)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(deliveryId);

            if (delivery == null)
                throw new Exception("Delivery not found.");

            delivery.DeliveryStatus = request.DeliveryStatus;

            if (request.DeliveryStatus == "Delivered")
            {
                delivery.DeliveredAt = DateTime.UtcNow;
            }

            await _repository.UpdateDeliveryAsync(delivery);
        }

        public async Task DeleteDeliveryAsync(Guid deliveryId)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(deliveryId);

            if (delivery == null)
                throw new Exception("Delivery not found.");

            await _repository.DeleteDeliveryAsync(delivery);
        }
    }
}