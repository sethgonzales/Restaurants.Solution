namespace Restaurants.Models
{
  public class Restaurant
  {
    public int RestaurantsId { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public Cuisine Cuisine { get; set; }
    public int CuisineId { get; set; }


  }
}