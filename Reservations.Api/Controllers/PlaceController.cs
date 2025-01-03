using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservations.Application.Place.GetAvailablePlaces;

namespace Reservations.Api.Controllers;

[Authorize]
public class PlaceController(IMediator mediator) : BaseController
{
    [HttpGet("available")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AvailablePlace>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> GetAvailablePlaces([FromQuery] GetAvailablePlacesQuery query)
    {
        return Ok(await mediator.Send(query));
    }

}