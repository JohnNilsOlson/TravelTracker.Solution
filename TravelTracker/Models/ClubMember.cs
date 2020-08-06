namespace TravelTracker.Models
{
  public class ClubMember
  {
    public int ClubMemberId { get; set; }
    public int ClubId { get; set; }
    public int TravellerId { get; set; }
    public Club Club { get; set; }
    public Traveller Traveller { get; set; }
  }
}