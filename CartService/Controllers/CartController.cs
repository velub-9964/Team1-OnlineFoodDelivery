using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartService.Data;
using CartService.DTOs;
using CartService.Models;



namespace CartService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartDbContext _context;

    public CartController(CartDbContext context)
    {
        _context = context;
    }

    //Add item
    [HttpPost("items")]
    public async Task<IActionResult> AddItem(
        AddCartItemDto dto)
    {
        var cart =
            await _context.Carts.Include(x => x.Items)
            .FirstOrDefaultAsync(
            x => x.CustomerId == dto.CustomerId);
        if (cart == null)
        {
            cart = new Cart
            {
                CartId = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
               
            };
            _context.Carts.Add(cart);


        }

        var item = new CartItem
        {
            CartItemId = Guid.NewGuid(),
            CartId = cart.CartId,
            MenuItemId = dto.MenuId,
            Quantity = dto.Quantity,
           
        };

        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);

    }


    //get cart

    [HttpGet("{CustomerId}")]
    public async Task<IActionResult> GetCart(
        int customerId)
    {
        var cart =
            await _context.Carts.Include(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);
        if (cart == null)
        {
            return Ok(cart);
        }
        return Ok(cart);
    }


    //update quantity
    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateItem(
        Guid id,
        UpdateCartItemDto dto)
    {
        var item=
            await _context.CartItems
            .FirstOrDefaultAsync(
                x => x.CartItemId == id);
        if (item == null)
        {
            return NotFound();
        }
        item.Quantity = dto.Quantity;
        await _context.SaveChangesAsync();
        return Ok(item);
    
     }



    //remove item
    [HttpDelete("items/{id}")]
    public async Task<IActionResult> RemoveItem(
        Guid id)
    {
        var item =
            await _context.CartItems
            .FirstOrDefaultAsync(
                x => x.CartItemId == id);
        if (item == null)
        {
            return NotFound();
        }
     
        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
        return Ok("Items removed from cart");

    }

}