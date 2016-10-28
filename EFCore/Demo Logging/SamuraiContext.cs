using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace Demo_Logging
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }

    public SamuraiContext()
    {
      
    }
    public SamuraiContext(DbContextOptions<SamuraiContext> options)
      : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer(
       "Server = (localdb)\\mssqllocaldb; Database = SamuraiDataLogging; Trusted_Connection = True; ");

      }
    }
   

  }
}