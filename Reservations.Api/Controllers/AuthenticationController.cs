using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reservations.Api.Controllers;

[Authorize]
public class AuthenticationController : BaseController
{
    [HttpGet]
    public ActionResult<string> Index()
    {
        return Ok("Reservations.Api Live Check!");
    }
}