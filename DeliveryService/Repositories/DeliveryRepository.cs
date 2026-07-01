using DeliveryService.Data;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliveryDbContext _context;

        public DeliveryRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> CreateDeliveryAsync(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);

            await _context.SaveChangesAsync();

            return delivery;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery?> GetDeliveryByIdAsync(Guid deliveryId)
        {
            return await _context.Deliveries.FindAsync(deliveryId);
        }

        public async Task UpdateDeliveryAsync(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeliveryAsync(Delivery delivery)
        {
            _context.Deliveries.Remove(delivery);

            await _context.SaveChangesAsync();
        }
    }
}