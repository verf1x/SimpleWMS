using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}