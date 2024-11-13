using DistanceArticle.Data.Configurations;
using DistanceArticle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DistanceArticle.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // we don't want ef core SQL logs.
        optionsBuilder.UseLoggerFactory(
            LoggerFactory.Create(builder =>
                builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Error)
            )
        );
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Venue>().HasIndex(v => v.Location);
        builder.Entity<VenueGeometry>().HasIndex(v => v.Location);
        builder.ApplyConfiguration(new VenueConfiguration());
        builder.ApplyConfiguration(new VenueGeometryConfiguration());
    }

    public DbSet<Venue> Venues { get; set; } = null!;
    public DbSet<VenueGeometry> VenueGeometries { get; set; } = null!;
}
