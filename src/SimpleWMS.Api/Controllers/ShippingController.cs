using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ShippingController : ControllerBase
{
    private readonly IMediator _mediator;
    public ShippingController(IMediator mediator) => _mediator = mediator;
        
    [HttpPost("cargo/{cargoId:guid}")]
    public async Task<IActionResult> ShipCargo(Guid cargoId)
    {
        await _mediator.Send(new ShipCargoCommand(cargoId));
        return NoContent();
    }
}