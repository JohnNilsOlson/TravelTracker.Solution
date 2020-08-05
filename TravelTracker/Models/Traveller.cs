using System.Collections.Generic;

namespace TravelTracker.Models
{
  public class Traveller
  {
    public Traveller()
    {
      this.Destinations = new HashSet<DestinationTraveller>();
    }
    public int TravellerId { get; set; }
    public string Name { get; set; }
    public ICollection<DestinationTraveller> Destinations {get; }
  }
}