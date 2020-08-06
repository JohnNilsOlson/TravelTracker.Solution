using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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

    public ActionResult AddTraveller(int id)
    {
      var thisDestination = _db.Destinations.FirstOrDefault(destination => destination.DestinationId == id);
      ViewBag.TravellerId = new SelectList(_db.Travellers, "TravellerId", "Name");
      return View(thisDestination);
    }

    [HttpPost]
    public ActionResult AddTraveller(Destination destination, int TravellerId, DateTime startDate, DateTime endDate)
    {
      if (TravellerId != 0)
      {
        _db.DestinationTraveller.Add(new DestinationTraveller() {TravellerId = TravellerId, DestinationId = destination.DestinationId, StartDate = startDate, EndDate = endDate });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = destination.DestinationId });
    }

    [HttpPost]
    public ActionResult DeleteTraveller(int joinId, int id)
    {
      var joinEntry = _db.DestinationTraveller.FirstOrDefault(entry => entry.DestinationTravellerId == joinId);
      _db.DestinationTraveller.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = id });
    }
  }
}