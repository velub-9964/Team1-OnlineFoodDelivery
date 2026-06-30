using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryHaolai.DTOs;
using FoodDeliveryHaolai.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantService.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _service.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}/menu")]
        // [Authorize("CUSTOMER")]
        public async Task<IActionResult> GetMenuItemByRestaurantId(int id)
        {
            var menuItem = await _service.GetMenuItemsByRestaurantIdAsync(id);
            return Ok(menuItem);
        }

        [HttpPost("menuitems")]
        // [Authorize("OWNER")]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto dto)
        {
            await _service.CreateMenuItemAsync(dto);
            return Ok(new { message = "MenuItem created successfully." });
        }

        [HttpPost("create")]
        // [Authorize("ADMIN")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            await _service.CreateRestaurantAsync(dto);
            return Ok(new { message = "Restaurant created successfully!" });
        }
    }
}