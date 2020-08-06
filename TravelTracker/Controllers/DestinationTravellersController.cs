using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace TravelTracker.Controllers
{
  public class DestinationTravellersController : Controller
  {
    private readonly TravelTrackerContext _db;

    public DestinationTravellersController(TravelTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      ViewBag.DestinationId = new SelectList(_db.Destinations, "DestinationId", "CityName");
      ViewBag.TravellerId = new SelectList(_db.Travellers, "TravellerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(DestinationTraveller destinationTraveller)
    {
      _db.DestinationTraveller.Add(destinationTraveller);
      _db.SaveChanges();
      return RedirectToAction("Index", "Destinations");
    }

    public ActionResult Edit(int id)
    {
      var joinEntry = _db.DestinationTraveller.FirstOrDefault(entry => entry.DestinationTravellerId == id);
      return View(joinEntry);
    }

    [HttpPost]
    public ActionResult Edit(DestinationTraveller destinationTraveller)
    {
      _db.Entry(destinationTraveller).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Delete(int id)
    {
      var joinEntry = _db.DestinationTraveller.FirstOrDefault(entry => entry.DestinationTravellerId == id);
      return View(joinEntry);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var joinEntry = _db.DestinationTraveller.FirstOrDefault(entry => entry.DestinationTravellerId == id);
      _db.DestinationTraveller.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}