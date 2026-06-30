
using RestaurantService.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Data;

namespace RestaurantService.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _context;
        public RestaurantRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(u=>
            u.RestaurantId == id);
        }

        public async Task<List<MenuItem>> GetMenuItemsByRestaurantIdAsync(int id)
        {
            return await _context.MenuItems.Where(u=>
                u.RestaurantId == id
            ).ToListAsync();
        }


        public async Task<MenuItem> GetMenuItemByNameAsync(string name)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(u=>
                u.Name == name
                );
        }

    }
}