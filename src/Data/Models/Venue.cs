using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace DistanceArticle.Data.Models;

public class Venue
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    [Column(TypeName = "geography")]
    public required Point Location { get; set; }
}
