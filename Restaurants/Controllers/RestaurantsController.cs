using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly RestaurantsContext _db; 
    public RestaurantsController(RestaurantsContext db) 
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Restaurants";
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList(); 
      return View(model);
    }

    public ActionResult Create() 
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");  
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant) 
    {
      ViewBag.PageTitle = "Create New Restaurants";
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);  
      _db.SaveChanges(); 
      return RedirectToAction("Index"); 
    }

    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Restaurant Details";
      Restaurant thisRestaurant = _db.Restaurants.Include(restaurant => restaurant.Cuisine).FirstOrDefault(restaurant => restaurant.RestaurantId == id); 
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id) 
    {
      ViewBag.PageTitle = "Edit Restaurant Details";
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id); 
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant) 
    {
      _db.Restaurants.Update(restaurant); 
      _db.SaveChanges(); 
      return RedirectToAction("Index"); 
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Restaurants";
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")] 
    public ActionResult DeleteConfirmed(int id) 
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id); 
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges(); 
      return RedirectToAction("Index");
    }
  }
}



