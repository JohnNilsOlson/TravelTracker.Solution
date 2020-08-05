using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TravelTracker.Controllers
{
  public class DestinationsController : Controller
  {
    private readonly TravelTrackerContext _db;

    public DestinationsController(TravelTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Destination> model = _db.Destinations.ToList();
      return View(model);
    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Destination destination)
    {
      _db.Destinations.Add(destination);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDestination = _db.Destinations
        .Include(destination => destination.Travellers)
        .ThenInclude(join => join.Traveller)
        .FirstOrDefault(destination => destination.DestinationId == id);
      return View(thisDestination);
    }

    public ActionResult Edit(int id)
    {
      var thisDestination = _db.Destinations.FirstOrDefault(destinations => destinations.DestinationId == id);
      return View(thisDestination);
    }

    [HttpPost]
    public ActionResult Edit(Destination destination)
    {
      _db.Entry(destination).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDestination = _db.Destinations.FirstOrDefault(destination => destination.DestinationId == id);
      return View(thisDestination);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDestination = _db.Destinations.FirstOrDefault(destination => destination.DestinationId == id);
      _db.Destinations.Remove(thisDestination);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}