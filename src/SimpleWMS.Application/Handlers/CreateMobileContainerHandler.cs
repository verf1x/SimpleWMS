using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Domain.ValueObjects;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CreateMobileContainerHandler
    : IRequestHandler<CreateMobileContainerCommand, Guid>
{
    private readonly SimpleWmsDbContext _dbContext;
    public CreateMobileContainerHandler(SimpleWmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateMobileContainerCommand cmd, CancellationToken ct)
    {
        var mcNumber = MobileContainerNumber.Parse(cmd.Number);
        
        if (await _dbContext.MobileContainers.AnyAsync(m => m.Number == mcNumber, ct))
            throw new InvalidOperationException($"MC {cmd.Number} already exists");

        var mc = new MobileContainer
        {
            Id = Guid.NewGuid(),
            Number = mcNumber
        };
        
        _dbContext.MobileContainers.Add(mc);
        await _dbContext.SaveChangesAsync(ct);
        return mc.Id;
    }
}