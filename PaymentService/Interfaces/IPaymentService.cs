using PaymentService.DTOs;

namespace PaymentService.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreatePaymentAsync(PaymentRequestDto request);

        Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync();

        Task<PaymentResponseDto?> GetPaymentByIdAsync(Guid paymentId);

        Task UpdatePaymentStatusAsync(Guid paymentId, UpdatePaymentStatusDto request);

        Task DeletePaymentAsync(Guid paymentId);
    }
}
