using DistanceArticle.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;

public class VenueGeometryConfiguration : IEntityTypeConfiguration<VenueGeometry>
{
    public void Configure(EntityTypeBuilder<VenueGeometry> builder)
    {
        builder.HasData(
            new VenueGeometry
            {
                Id = 1,
                Name = "Central Park",
                Location = new Point(-73.9654, 40.7851) { SRID = 4326 },
            },
            new VenueGeometry
            {
                Id = 2,
                Name = "Statue of Liberty",
                Location = new Point(-74.0445, 40.6892) { SRID = 4326 },
            },
            new VenueGeometry
            {
                Id = 3,
                Name = "Empire State Building",
                Location = new Point(-73.9857, 40.7488) { SRID = 4326 },
            },
            new VenueGeometry
            {
                Id = 4,
                Name = "Times Square",
                Location = new Point(-73.9855, 40.7580) { SRID = 4326 },
            },
            new VenueGeometry
            {
                Id = 5,
                Name = "Brooklyn Bridge",
                Location = new Point(-73.9969, 40.7061) { SRID = 4326 },
            },
            new VenueGeometry
            {
                Id = 6,
                Name = "One World Trade Center",
                Location = new Point(-74.0134, 40.7127) { SRID = 4326 },
            }
        );
    }
}
