using DistanceArticle.Data;
using HenryUtils.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace DistanceArticle.Features.Venue.GetVenues
{
    public class GetVenuesRequest : IRequest<Result<IEnumerable<VenueDto>>>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double RangeInKm { get; set; }
    }

    public class VenueDto
    {
        public required string Name { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        public static VenueDto FromVenue(Data.Models.Venue venue)
        {
            return new VenueDto
            {
                Name = venue.Name,
                Latitude = venue.Location.Y,
                Longitude = venue.Location.X,
            };
        }
    }

    public class GetVenuesRequestHandler(ApplicationDbContext dbContext, ILogger<GetVenuesRequestHandler> logger)
        : IRequestHandler<GetVenuesRequest, Result<IEnumerable<VenueDto>>>
    {
        public async Task<Result<IEnumerable<VenueDto>>> Handle(GetVenuesRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Getting venues near {Latitude}, {Longitude} with range {RangeInKm} km",
                request.Latitude,
                request.Longitude,
                request.RangeInKm
            );

            var userLocation = new Point(request.Longitude, request.Latitude) { SRID = 4326 };

            var venues = await dbContext
                .Venues.Where(v => v.Location.Distance(userLocation) <= request.RangeInKm * 1000)
                .OrderBy(v => v.Location.Distance(userLocation))
                .ToListAsync(cancellationToken: cancellationToken);

            var venuesDto = venues.Select(v => VenueDto.FromVenue(v));

            return Result<IEnumerable<VenueDto>>.Success(venuesDto);
        }
    }
}
