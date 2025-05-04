using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Domain.Enums;
using SimpleWMS.Domain.ValueObjects;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CreateCrateHandler : IRequestHandler<CreateCrateCommand, Guid>
{
    private readonly SimpleWmsDbContext _dbContext;
    public CreateCrateHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateCrateCommand cmd, CancellationToken ct)
    {
        var code = CrateLocationCode.Parse(cmd.LocationCode);
        
        if (await _dbContext.Crates.AnyAsync(c => c.LocationCode == code, ct))
            throw new InvalidOperationException($"Crate {cmd.LocationCode} already exists");
        
        var crate = new Crate
        {
            Id = Guid.NewGuid(),
            Status = CrateStatus.Opened
        };
        
        crate.AssignLocation(cmd.LocationCode);

        _dbContext.Crates.Add(crate);
        await _dbContext.SaveChangesAsync(ct);
        return crate.Id;
    }
}