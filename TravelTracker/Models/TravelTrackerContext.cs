using Microsoft.EntityFrameworkCore;

namespace TravelTracker.Models
{
  public class TravelTrackerContext : DbContext
  {
    public virtual DbSet<Destination> Destinations { get; set; }
    public DbSet<Traveller> Travellers { get; set; }
    public DbSet<DestinationTraveller> DestinationTraveller { get; set; }

    public TravelTrackerContext(DbContextOptions options) : base(options) { }
  }
}