using Microsoft.EntityFrameworkCore;

namespace Restaurants.Models
{
  public class RestaurantsContext : DbContext 
  {
    public DbSet<Restaurant> Restaurants { get; set; } 
     public DbSet<Cuisine> Cuisines { get; set; }

    public RestaurantsContext(DbContextOptions options) : base(options) { } 
  }
}