using System.Collections.Generic;

namespace Restaurants.Models
{
    public class Cuisine
    {
        public int CuisineId { get; set; }
        public string Name { get; set; }
        public List<Restaurant> Restaurants { get; set; } //not in the database, but acts as a nav link to the Items model, showing that items and categories are related 
    }
}