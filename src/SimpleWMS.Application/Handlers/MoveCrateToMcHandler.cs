using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class MoveCrateToMcHandler : IRequestHandler<MoveCrateToMcCommand>
{
    private readonly SimpleWmsDbContext _db;
    public MoveCrateToMcHandler(SimpleWmsDbContext db) => _db = db;

    public async Task<Unit> Handle(MoveCrateToMcCommand cmd, CancellationToken ct)
    {
        var crate = await _db.Crates
                        .SingleOrDefaultAsync(c => c.Id == cmd.CrateId, ct)
                    ?? throw new KeyNotFoundException("Crate not found");

        var mcNumber = MobileContainerNumber.Parse(cmd.McNumber);
        var mc = await _db.MobileContainers
                     .SingleOrDefaultAsync(m => m.Number == mcNumber, ct)
                 ?? throw new KeyNotFoundException("Mobile container not found");

        crate.MoveToMobileContainer(mc.Id);

        await _db.SaveChangesAsync(ct);
        return Unit.Value;
    }
}