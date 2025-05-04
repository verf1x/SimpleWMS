using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Api.Models;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CargoController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CargoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCargoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok();
    }
    
    [HttpPost("{id:guid}/add-instance")]
    public async Task<IActionResult> AddInstance(
        [FromRoute] Guid id,
        [FromBody] AddInstanceToCargoRequest request)
    {
        var command = new AddInstanceToCargoCommand(id, request.InstanceBarcode);
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("{id:guid}/close")]
    public async Task<IActionResult> Close(Guid id)
    {
        await _mediator.Send(new CloseCargoCommand(id));
        return NoContent();
    }
    
    [HttpPost("{id:guid}/add-crate")]
    public async Task<IActionResult> AddCrate(Guid id, [FromBody] AddCrateToCargoRequest req)
    {
        await _mediator.Send(new AddCrateToCargoCommand(id, req.CrateId));
        return NoContent();
    }
}