using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;

namespace RestaurantService.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(
            DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}