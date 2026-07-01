using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<Delivery> CreateDeliveryAsync(Delivery delivery);

        Task<IEnumerable<Delivery>> GetAllDeliveriesAsync();

        Task<Delivery?> GetDeliveryByIdAsync(Guid deliveryId);

        Task UpdateDeliveryAsync(Delivery delivery);

        Task DeleteDeliveryAsync(Delivery delivery);
    }
}