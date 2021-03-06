using System.Collections.Generic;

namespace TravelTracker.Models
{
  public class Traveller
  {
    public Traveller()
    {
      this.Trips = new HashSet<Trip>();
    }
    public int TravellerId { get; set; }
    public string Name { get; set; }
    public ICollection<Trip> Trips { get; }
  }
}