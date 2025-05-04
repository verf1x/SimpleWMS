using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Api.Models;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MobileContainerController : ControllerBase
{
    private readonly IMediator _mediator;
    public MobileContainerController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMobileContainerRequest req)
    {
        var id = await _mediator.Send(new CreateMobileContainerCommand(req.Number));
        return CreatedAtAction(null, new { id }, new { id });
    }
}