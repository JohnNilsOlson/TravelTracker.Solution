using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace TravelTracker.Controllers
{
  public class TripsController : Controller
  {
    private readonly TravelTrackerContext _db;"

    public TripsController(TravelTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    
    

    [HttpPost]
    public ActionResult SoloCreate(Trip trip)
    {
      _db.Trips.Add(trip);
      _db.SaveChanges();
      return RedirectToAction("Index", "Destinations");
    }

    [HttpPost]
    public ActionResult GroupCreate(Trip trip)
    {
      _db.Trips.Add(trip);
      _db.SaveChanges();
      return RedirectToAction("Index", "Destinations");
    }

    public ActionResult Edit(int id)
    {
      var joinEntry = _db.Trips.FirstOrDefault(entry => entry.TripId == id);
      return View(joinEntry);
    }

    [HttpPost]
    public ActionResult Edit(Trip trip)
    {
      _db.Entry(trip).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Delete(int id)
    {
      var joinEntry = _db.Trips.FirstOrDefault(entry => entry.TripId == id);
      return View(joinEntry);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var joinEntry = _db.Trips.FirstOrDefault(entry => entry.TripId == id);
      _db.Trips.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}