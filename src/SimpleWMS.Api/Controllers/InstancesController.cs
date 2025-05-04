using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWMS.Api.Models;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InstancesController : ControllerBase
{
    private readonly IMediator _mediator;
    public InstancesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("expected")]
    public async Task<IActionResult> AddExpected(
        [FromBody] List<CreateExpectedInstanceRequest> list)
    {
        var command = new CreateExpectedInstancesCommand(
            list.Select(x => new CreateExpectedInstanceDto(x.ShippingNumber, x.SortType)).ToList());

        var ids = await _mediator.Send(command);
        return Created(nameof(GetById), ids);
    }
    
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
        => Ok($"Instance {id} created");
}