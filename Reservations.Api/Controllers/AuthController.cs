using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Reservations.Api.Controllers;

public class AuthController() : BaseController
{
    
    [HttpGet]
    public async Task<ActionResult<string>> Authenticate()
    {
        return Ok("Hello World");
    }
}