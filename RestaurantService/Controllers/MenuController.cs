using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Data;
using RestaurantService.Models;

namespace RestaurantService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public MenuController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/Menu/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetById(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
                return NotFound("Menu item not found");

            return Ok(menuItem);
        }

        // GET: api/Menu/restaurant/1
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetByRestaurant(int restaurantId)
        {
            var menuItems = await _context.MenuItems
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();

            if (!menuItems.Any())
                return NotFound("No menu items found for this restaurant");

            return Ok(menuItems);
        }

        // POST: api/Menu
        [HttpPost]
        public async Task<ActionResult<MenuItem>> Create(MenuItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurantExists = await _context.Restaurants
                .AnyAsync(r => r.RestaurantId == item.RestaurantId);

            if (!restaurantExists)
                return BadRequest("Restaurant does not exist");

            _context.MenuItems.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = item.MenuItemId },
                item);
        }

        // PUT: api/Menu/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != item.MenuItemId)
                return BadRequest("Menu Item ID mismatch");

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.MenuItems.AnyAsync(m => m.MenuItemId == id))
                    return NotFound("Menu item not found");

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Menu/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
                return NotFound("Menu item not found");

            _context.MenuItems.Remove(menuItem);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}