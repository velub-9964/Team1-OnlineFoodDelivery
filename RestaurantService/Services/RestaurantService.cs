
using RestaurantService.DTOs;
using RestaurantService.Models;
using RestaurantService.Repositories;

namespace RestaurantService.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateMenuItemAsync(CreateMenuItemDto dto)
        {
            await GetMenuItemByNameAsync(dto.Name);

            MenuItem menuItem = new MenuItem
            {
                RestaurantId = dto.RestaurantId,
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                IsAvailable = dto.IsAvailable
            };
            await _repository.CreateMenuItemAsync(menuItem);
        }

        public async Task CreateRestaurantAsync(CreateRestaurantDto dto)
        {
            Restaurant restaurant = new Restaurant
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                Status = dto.Status,
            };
            await _repository.CreateRestaurantAsync(restaurant);
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _repository.GetAllRestaurantsAsync();
        }

        public async Task GetMenuItemByNameAsync(string name)
        {
            var menuItem = await _repository.GetMenuItemByNameAsync(name);
            if(menuItem != null)
                throw new Exception("Menu Item already exists!");
        }

        public async Task<List<MenuItem>> GetMenuItemsByRestaurantIdAsync(int id)
        {
            var restaurant = await _repository.GetRestaurantByIdAsync(id);
            if(restaurant == null)
                throw new Exception("Restaurant not available!");
            var menuItem = await _repository.GetMenuItemsByRestaurantIdAsync(id);
            return menuItem;
        }
    }
}