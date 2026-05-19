using Leads.Application.Features.Commands.Lead;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leads.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(
        [FromBody] AddLeadCommand command,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] object request,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Remove(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}