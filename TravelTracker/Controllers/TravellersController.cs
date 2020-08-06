using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace TravelTracker.Controllers
{
  public class TravellersController : Controller
  {
    private readonly TravelTrackerContext _db;

    public TravellersController(TravelTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Traveller> model = _db.Travellers.ToList();
      return View(model);
    }
    
    public ActionResult Create()
    {
      ViewBag.DestinationId = new SelectList(_db.Destinations, "DestinationId", "CityName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Traveller traveller)
    {
      _db.Travellers.Add(traveller);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTraveller = _db.Travellers
        .Include(traveller => traveller.Trips)
        .ThenInclude(join => join.Destination)
        // .ThenInclude(join => join.Club)
        .FirstOrDefault(traveller => traveller.TravellerId == id);
      return View(thisTraveller);
    }

    public ActionResult Edit(int id)
    {
      var thisTraveller = _db.Travellers.FirstOrDefault(travellers => travellers.TravellerId == id);
      return View(thisTraveller);
    }

    [HttpPost]
    public ActionResult Edit(Traveller traveller)
    {
      _db.Entry(traveller).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTraveller = _db.Travellers.FirstOrDefault(traveller => traveller.TravellerId == id);
      return View(thisTraveller);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTraveller = _db.Travellers.FirstOrDefault(traveller => traveller.TravellerId == id);
      _db.Travellers.Remove(thisTraveller);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}