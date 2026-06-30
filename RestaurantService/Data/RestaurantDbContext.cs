using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;

namespace RestaurantService.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants {get; set;}
        public DbSet<MenuItem> MenuItems {get; set;}
    }
}