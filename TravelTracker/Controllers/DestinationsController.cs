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
  }
}