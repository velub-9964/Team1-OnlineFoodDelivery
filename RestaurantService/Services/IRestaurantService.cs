
using RestaurantService.DTOs;
using RestaurantService.Models;

namespace RestaurantService.Services
{
    public interface IRestaurantService
    {
        Task CreateMenuItemAsync(CreateMenuItemDto dto);
        Task CreateRestaurantAsync(CreateRestaurantDto dto);
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<List<MenuItem>> GetMenuItemsByRestaurantIdAsync(int id);
        Task GetMenuItemByNameAsync(string name);
    }
}