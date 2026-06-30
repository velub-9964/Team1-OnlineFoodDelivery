using PaymentService.Models;

namespace PaymentService.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<IEnumerable<Payment>> GetAllPaymentsAsync();

        Task<Payment?> GetPaymentByIdAsync(Guid paymentId);

        Task<Payment?> GetPaymentByOrderIdAsync(Guid orderId);

        Task UpdatePaymentAsync(Payment payment);

        Task DeletePaymentAsync(Guid paymentId);

        Task SaveChangesAsync();
    }
}
