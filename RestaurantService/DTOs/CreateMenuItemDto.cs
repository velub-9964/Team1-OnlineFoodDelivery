using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantService.DTOs
{
    public class CreateMenuItemDto
    {
        public int RestaurantId {get; set;}
        public string Name {get; set;}
        public decimal Price {get; set;}
        public string Category {get; set;}
        public string IsAvailable {get; set;}
    }
}