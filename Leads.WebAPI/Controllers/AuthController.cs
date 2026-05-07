using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leads.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("auth")]
    public async Task<IActionResult> Login(
        [FromBody] object request,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}