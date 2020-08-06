using System.Collections.Generic;

namespace TravelTracker.Models
{
  public class Destination
  {
    public Destination()
    {
      this.Trips = new HashSet<Trip>();
    }

    public int DestinationId { get; set; }
    public string CityName { get; set; }
    public virtual ICollection<Trip> Trips { get; set; }
  }
}