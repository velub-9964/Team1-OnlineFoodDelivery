using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.DTOs;
using OrderService.Models;



namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderDbContext _context;

    public OrderController(OrderDbContext context)
    {
        _context = context;
    }

    //Post
    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        CreateOrderDto dto)
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            RestaurantId = dto.RestaurantId,
            Amount = dto.Amount,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return Ok(new
        {
            message = "order created successfully",
            orderId = order.OrderId
        });
    }

    //GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound(new { message = "Order not found" });
        }

        return Ok(order);
    }


    //Get customer{id}
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetCustomerOrders(int customerId)
    {
        var orders = await _context.Orders
            .Where(x => x.CustomerId == customerId).ToListAsync();
        if (orders.Count == 0)
        {
            return NotFound(new { message = "No orders found for this customer" });
        }
        return Ok(orders);

    }

    //PUT order
    [HttpPut("{id}/status")]

    public async Task<IActionResult> UpdateStatus(
        Guid id,
        UpdateOrderStatusDto dto)
    {
        var order =
            await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        if (order == null)
        {
            return NotFound();
        }

        order.Status = dto.Status;
        await _context.SaveChangesAsync();

        return Ok(new { message = "Order status updated successfully" });
    }

    //Delete  orders using id

    [HttpDelete("{id}")]

    public async Task<IActionResult> CancelOrder(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x =>x.OrderId == id);

        if(order == null)
        {
            return NotFound();
        }

        order.Status = "Cancelled";
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Order Cancelled"
        });
}
}
