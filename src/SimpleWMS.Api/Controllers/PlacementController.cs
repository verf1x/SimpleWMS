using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PlacementController : ControllerBase
{
    private readonly IMediator _mediator;
    public PlacementController(IMediator mediator) => _mediator = mediator;

    [HttpPost("mc")]
    public async Task<IActionResult> PlaceToMC([FromBody] PlaceInstanceToMCCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("crate")]
    public async Task<IActionResult> PlaceToCrate([FromBody] PlaceInstanceToCrateCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}