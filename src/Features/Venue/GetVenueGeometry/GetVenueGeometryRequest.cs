using DistanceArticle.Data;
using HenryUtils.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace DistanceArticle.Features.Venue.GetVenueGeometry;

public class GetVenueGeometryRequest : IRequest<Result<IEnumerable<VenueGeometryDto>>>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double RangeInKm { get; set; }
}

public class VenueGeometryDto
{
    public required string Name { get; set; }
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }

    public static VenueGeometryDto FromVenueGeometry(Data.Models.VenueGeometry venueGeometry)
    {
        return new VenueGeometryDto
        {
            Name = venueGeometry.Name,
            Latitude = venueGeometry.Location.Y,
            Longitude = venueGeometry.Location.X,
        };
    }
}

public class GetVenueGeometryRequestHandler(ApplicationDbContext dbContext, ILogger<GetVenueGeometryRequestHandler> logger)
    : IRequestHandler<GetVenueGeometryRequest, Result<IEnumerable<VenueGeometryDto>>>
{
    public async Task<Result<IEnumerable<VenueGeometryDto>>> Handle(GetVenueGeometryRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Getting venues near {Latitude}, {Longitude} with range {RangeInKm} km",
            request.Latitude,
            request.Longitude,
            request.RangeInKm
        );

        var userLocation = new Point(request.Longitude, request.Latitude) { SRID = 4326 };

        var venues = await dbContext
            .VenueGeometries.Where(v => v.Location.Distance(userLocation) <= request.RangeInKm * 1000)
            .OrderBy(v => v.Location.Distance(userLocation))
            .ToListAsync(cancellationToken: cancellationToken);

        var venuesDto = venues.Select(v => VenueGeometryDto.FromVenueGeometry(v));

        return Result<IEnumerable<VenueGeometryDto>>.Success(venuesDto);
    }
}
