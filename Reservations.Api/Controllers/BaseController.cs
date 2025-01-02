using Microsoft.AspNetCore.Mvc;

namespace Reservations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BaseController : ControllerBase { }