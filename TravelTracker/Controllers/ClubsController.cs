using Microsoft.AspNetCore.Mvc;
using TravelTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace TravelTracker.Controllers
{
  public class ClubsController : Controller
  {
    private readonly TravelTrackerContext _db;

    public ClubsController(TravelTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Club> model = _db.Clubs.ToList();
      return View(model);
    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Club club)
    {
      _db.Clubs.Add(club);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisClub = _db.Clubs
        .Include(club => club.Trips)
        .Include(club => club.Members)
        .ThenInclude(join => join.Traveller)
        // .ThenInclude(join => join.Destination)
        // .ThenInclude(join => join.Traveller)
        .FirstOrDefault(club => club.ClubId == id);
      return View(thisClub);
    }

    public ActionResult Edit(int id)
    {
      var thisClub = _db.Clubs.FirstOrDefault(clubs => clubs.ClubId == id);
      return View(thisClub);
    }

    [HttpPost]
    public ActionResult Edit(Club club)
    {
      _db.Entry(club).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisClub = _db.Clubs.FirstOrDefault(club => club.ClubId == id);
      return View(thisClub);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisClub = _db.Clubs.FirstOrDefault(club => club.ClubId == id);
      _db.Clubs.Remove(thisClub);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTraveller(int id)
    {
      var thisClub = _db.Clubs.FirstOrDefault(club => club.ClubId == id);
      ViewBag.TravellerId = new SelectList(_db.Travellers, "TravellerId", "Name");
      return View(thisClub);
    }

    [HttpPost]
    public ActionResult AddTraveller(Club club, int TravellerId)
    {
      if (TravellerId != 0)
      {
        _db.ClubMember.Add(new ClubMember() { TravellerId = TravellerId, ClubId = club.ClubId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = club.ClubId });
    }
  }
}