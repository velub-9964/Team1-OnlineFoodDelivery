using DeliveryService.DTOs;

namespace DeliveryService.Interfaces
{
    public interface IDeliveryService
    {
        Task<DeliveryResponseDto> CreateDeliveryAsync(DeliveryRequestDto request);

        Task<IEnumerable<DeliveryResponseDto>> GetAllDeliveriesAsync();

        Task<DeliveryResponseDto?> GetDeliveryByIdAsync(Guid deliveryId);

        Task UpdateDeliveryStatusAsync(Guid deliveryId, UpdateDeliveryStatusDto request);

        Task DeleteDeliveryAsync(Guid deliveryId);
    }
}