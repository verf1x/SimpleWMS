using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Api.Models;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CrateController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrateController(IMediator mediator) => _mediator = mediator;

    [HttpPost("close/{id}")]
    public async Task<IActionResult> Close(Guid id)
    {
        await _mediator.Send(new CloseCrateCommand(id));
        return NoContent();
    }
    
    [HttpPost("{id:guid}/move-to-mc")]
    public async Task<IActionResult> MoveToMc(Guid id, [FromBody] MoveCrateToMcRequest req)
    {
        await _mediator.Send(new MoveCrateToMcCommand(id, req.McNumber));
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCrateRequest req)
    {
        var id = await _mediator.Send(new CreateCrateCommand(req.LocationCode));
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(new { id });
    }
}