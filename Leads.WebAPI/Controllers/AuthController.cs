using Leads.Application.Features.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leads.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody] AuthCommand command,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            command,
            cancellationToken);

        return StatusCode(
            response.StatusCode,
            response);
    }
}