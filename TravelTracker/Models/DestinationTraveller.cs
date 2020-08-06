using System;

namespace TravelTracker.Models
{
  public class DestinationTraveller
  {
    public int DestinationTravellerId { get; set; }
    public int DestinationId { get; set; }
    public int TravellerId { get; set; }
    public Traveller Traveller { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Destination Destination { get; set; }
  }
}