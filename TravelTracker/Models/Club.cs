using System.Collections.Generic;

namespace TravelTracker.Models
{
  public class Club
  {
    public Club()
    {
      this.Trips = new HashSet<Trip>();
      this.Members = new HashSet<ClubMember>();
    }
    public int ClubId { get; set; }
    public string Name { get; set; }
    public ICollection<Trip> Trips { get; }
    public ICollection<ClubMember> Members { get; }
  }
}