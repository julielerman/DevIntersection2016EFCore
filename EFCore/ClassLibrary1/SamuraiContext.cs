using Microsoft.EntityFrameworkCore;

namespace Mappings
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SamuraiDataMappings; Trusted_Connection = True; ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Samurai>()
        .Property(s => s.ImmutableName)
        .HasField("_name");
    }
  }
}