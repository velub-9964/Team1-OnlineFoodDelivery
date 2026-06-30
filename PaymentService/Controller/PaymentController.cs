using Microsoft.AspNetCore.Mvc;
using PaymentService.DTOs;
using PaymentService.Interfaces;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentRequestDto request)
        {
            var result = await _paymentService.CreatePaymentAsync(request);
            return CreatedAtAction(nameof(GetPaymentById),
                new { paymentId = result.PaymentId }, result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetAllPaymentsAsync();
            return Ok(result);
        }

        
        [HttpGet("{paymentId:guid}")]
        public async Task<IActionResult> GetPaymentById(Guid paymentId)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(paymentId);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        
        [HttpPut("{paymentId:guid}")]
        public async Task<IActionResult> UpdatePaymentStatus(
            Guid paymentId,
            UpdatePaymentStatusDto request)
        {
            await _paymentService.UpdatePaymentStatusAsync(paymentId, request);

            return NoContent();
        }

       
        [HttpDelete("{paymentId:guid}")]
        public async Task<IActionResult> DeletePayment(Guid paymentId)
        {
            await _paymentService.DeletePaymentAsync(paymentId);

            return NoContent();
        }
    }
}