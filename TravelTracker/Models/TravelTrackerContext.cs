using Microsoft.EntityFrameworkCore;

namespace TravelTracker.Models
{
  public class TravelTrackerContext : DbContext
  {
    public virtual DbSet<Destination> Destinations { get; set; }
    public DbSet<Traveller> Travellers { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Trip> Trips { get; set; }

    public TravelTrackerContext(DbContextOptions options) : base(options) { }
  }
}