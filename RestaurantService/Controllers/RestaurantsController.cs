using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Data;
using RestaurantService.Models;

namespace RestaurantService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }

        // GET: api/Restaurants/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetById(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
                return NotFound("Restaurant not found");

            return Ok(restaurant);
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<ActionResult<Restaurant>> Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Restaurants.Add(restaurant);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = restaurant.RestaurantId },
                restaurant);
        }

        // PUT: api/Restaurants/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != restaurant.RestaurantId)
                return BadRequest("Restaurant ID mismatch");

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Restaurants.AnyAsync(r => r.RestaurantId == id))
                    return NotFound("Restaurant not found");

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Restaurants/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
                return NotFound("Restaurant not found");

            _context.Restaurants.Remove(restaurant);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}