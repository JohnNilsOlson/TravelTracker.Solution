using System;

namespace TravelTracker.Models
{
  public class Trip
  {
    public int TripId { get; set; }
    public int DestinationId { get; set; }
    public Nullable<int> TravellerId { get; set; }
    public Nullable<int> ClubId { get; set; }
    public Club Club { get; set; }
    public Traveller Traveller { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Destination Destination { get; set; }
  }
}