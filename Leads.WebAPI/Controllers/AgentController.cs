using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leads.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgentController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] object request,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] object request,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}