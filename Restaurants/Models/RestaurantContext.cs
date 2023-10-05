using Microsoft.EntityFrameworkCore;

namespace Restaurants.Models
{
  public class RestaurantContext : DbContext //create reference to database and extend functionality of EF Core's DBContext class
  {
    public DbSet<Restaurant> Restuarants { get; set; } //items property matching our items table in our database. Declare class name in <<
     public DbSet<Cuisine> Cuisines { get; set; }

    public RestaurantContext(DbContextOptions options) : base(options) { } //constructor that inherits DBContext class behaviors, with prevention of dependency injections 
  }
}