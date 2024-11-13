using DistanceArticle.Features.Venue.GetVenueGeometry;
using DistanceArticle.Features.Venue.GetVenues;
using HenryUtils.Api.Controllers;
using HenryUtils.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DistanceArticle.Features.Venue
{
    public class VenueController(IMediator mediator) : BaseController
    {
        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyVenues([FromQuery] GetVenuesRequest request)
        {
            var result = await mediator.Send(request);
            return result.Match(_ => Ok(result.ToSuccessfulApiResponse()), ReturnErrorResponse);
        }

        [HttpGet("geometry")]
        public async Task<IActionResult> GetNearbyVenueGeometry([FromQuery] GetVenueGeometryRequest request)
        {
            var result = await mediator.Send(request);
            return result.Match(_ => Ok(result.ToSuccessfulApiResponse()), ReturnErrorResponse);
        }
    }
}
