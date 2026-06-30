using PaymentService.DTOs;
using PaymentService.Interfaces;
using PaymentService.Models;

namespace PaymentService.Services
{
    public class PaymentServices : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentServices(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResponseDto> CreatePaymentAsync(PaymentRequestDto request)
        {
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid(),
                OrderId = request.OrderId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = "Pending",
                TransactionId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow
            };

            await _repository.CreatePaymentAsync(payment);

            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
                TransactionId = payment.TransactionId,
                CreatedAt = payment.CreatedAt
            };
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync()
        {
            var payments = await _repository.GetAllPaymentsAsync();

            return payments.Select(payment => new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
                TransactionId = payment.TransactionId,
                CreatedAt = payment.CreatedAt
            });
        }

        public async Task<PaymentResponseDto?> GetPaymentByIdAsync(Guid paymentId)
        {
            var payment = await _repository.GetPaymentByIdAsync(paymentId);

            if (payment == null)
                return null;

            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
                TransactionId = payment.TransactionId,
                CreatedAt = payment.CreatedAt
            };
        }

        public async Task UpdatePaymentStatusAsync(Guid paymentId, UpdatePaymentStatusDto request)
        {
            var payment = await _repository.GetPaymentByIdAsync(paymentId);

            if (payment == null)
                throw new Exception("Payment not found.");

            payment.Status = request.Status;

            await _repository.UpdatePaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(Guid paymentId)
        {
            await _repository.DeletePaymentAsync(paymentId);
        }
    }
}