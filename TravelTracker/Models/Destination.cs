using System.Collections.Generic;

namespace TravelTracker.Models
{
  public class Destination
  {
    public Destination()
    {
      this.Travellers = new HashSet<DestinationTraveller>();
    }

    public int DestinationId { get; set; }
    public string CityName { get; set; }
    public virtual ICollection<DestinationTraveller> Travellers { get; set; }
  }
}