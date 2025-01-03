using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservations.Api.Shared;
using Reservations.Application.User.GetUserBasicInfo;


namespace Reservations.Api.Controllers;

[Authorize]
public class UserController(IMediator mediator, IHttpContextAccessor contextAccessor) : BaseController
{
    [HttpGet("basic-info")]
    [ProducesResponseType(typeof(UserBasicInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> GetBasicInfo()
    {
        return Ok(await mediator.Send(new GetUserBasicInfoQuery(contextAccessor.GetUserIdHttpContext())));
    }
}