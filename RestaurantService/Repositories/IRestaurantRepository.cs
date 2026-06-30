
using RestaurantService.Models;

namespace RestaurantService.Repositories
{
    public interface IRestaurantRepository
    {
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task CreateRestaurantAsync(Restaurant restaurant);
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task <List<MenuItem>> GetMenuItemsByRestaurantIdAsync(int id);
        Task <Restaurant> GetRestaurantByIdAsync(int id);
        Task<MenuItem> GetMenuItemByNameAsync(string name);
    }
}