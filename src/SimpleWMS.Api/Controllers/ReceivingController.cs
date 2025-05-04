using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Api.Models;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReceivingController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ReceivingController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("transportation")]
    public async Task<IActionResult> ReceiveTransportation([FromBody] ReceiveTransportationCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost]
    [Route("instance")]
    public async Task<IActionResult> ReceiveInstance([FromBody] ReceiveInstanceCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("cargo")]
    public async Task<IActionResult> ReceiveCargo([FromBody] ReceiveCargoRequest req)
    {
        await _mediator.Send(new ReceiveCargoCommand(req.CargoBarcode));
        return NoContent();
    }
}