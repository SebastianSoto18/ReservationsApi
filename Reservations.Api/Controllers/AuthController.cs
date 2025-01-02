using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservations.Application.User.AuthUser;

namespace Reservations.Api.Controllers;

public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<string>> Authenticate([FromBody] AuthUserCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}