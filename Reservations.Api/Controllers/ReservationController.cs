using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservations.Api.Shared;
using Reservations.Application.Reservation.GetReservationsByUser;

namespace Reservations.Api.Controllers;

[Authorize]
public class ReservationController(IMediator mediator, IHttpContextAccessor contextAccessor) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ReservationsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IReadOnlyCollection<ReservationsDto>>> GetReservations([FromQuery] int? startTime, [FromQuery] int? endTime, DateTime? date )
    {
        return Ok(await mediator.Send(new GetReservationsByUserQuery(contextAccessor.GetUserIdHttpContext(),startTime,endTime,date)));
    }
    
}