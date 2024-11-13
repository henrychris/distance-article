using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace DistanceArticle.Data.Models;

public class VenueGeometry
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required Point Location { get; set; }
}
