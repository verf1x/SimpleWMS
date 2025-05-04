using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Application.Commands;
using SimpleWMS.Application.Queries;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransportationController : ControllerBase
{
    private readonly IMediator _mediator;
    public TransportationController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [Authorize(Roles = "Logist")]
    public async Task<IActionResult> Create([FromBody] CreateTransportationCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWithCargo), new { id }, new { id });
    }

    [HttpPost("{transportationId:guid}/cargo/{cargoId:guid}")]
    [Authorize(Roles = "Logist")]
    public async Task<IActionResult> AddCargo(Guid transportationId, Guid cargoId)
    {
        await _mediator.Send(new AddCargoToTransportationCommand(transportationId, cargoId));
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWithCargo(Guid id)
    {
        var dto = await _mediator.Send(new GetTransportationWithCargoQuery(id));
        return Ok(dto);
    }
}