using DeliveryService.DTOs;
using DeliveryService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        // POST: api/delivery
        [HttpPost]
        public async Task<IActionResult> CreateDelivery(DeliveryRequestDto request)
        {
            var result = await _deliveryService.CreateDeliveryAsync(request);

            return CreatedAtAction(nameof(GetDeliveryById),
                new { deliveryId = result.DeliveryId }, result);
        }

        // GET: api/delivery
        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var result = await _deliveryService.GetAllDeliveriesAsync();

            return Ok(result);
        }

        // GET: api/delivery/{deliveryId}
        [HttpGet("{deliveryId:guid}")]
        public async Task<IActionResult> GetDeliveryById(Guid deliveryId)
        {
            var delivery = await _deliveryService.GetDeliveryByIdAsync(deliveryId);

            if (delivery == null)
                return NotFound();

            return Ok(delivery);
        }

        // PUT: api/delivery/{deliveryId}
        [HttpPut("{deliveryId:guid}")]
        public async Task<IActionResult> UpdateDeliveryStatus(
            Guid deliveryId,
            UpdateDeliveryStatusDto request)
        {
            await _deliveryService.UpdateDeliveryStatusAsync(deliveryId, request);

            var updatedDelivery = await _deliveryService.GetDeliveryByIdAsync(deliveryId);

            return Ok(updatedDelivery);
        }

        // DELETE: api/delivery/{deliveryId}
        [HttpDelete("{deliveryId:guid}")]
        public async Task<IActionResult> DeleteDelivery(Guid deliveryId)
        {
            await _deliveryService.DeleteDeliveryAsync(deliveryId);

            return NoContent();
        }
    }
}