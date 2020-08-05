using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TravelTracker.Models
{
  public class TravelTrackerContextFactory : IDesignTimeDbContextFactory<TravelTrackerContext>
  {
    TravelTrackerContext IDesignTimeDbContextFactory<TravelTrackerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<TravelTrackerContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new TravelTrackerContext(builder.Options);
    }
  }
}