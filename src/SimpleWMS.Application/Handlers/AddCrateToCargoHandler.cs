using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class AddCrateToCargoHandler : IRequestHandler<AddCrateToCargoCommand>
{
    private readonly SimpleWmsDbContext _dbContextContext;
    public AddCrateToCargoHandler(SimpleWmsDbContext dbContext) => _dbContextContext = dbContext;

    public async Task<Unit> Handle(AddCrateToCargoCommand cmd, CancellationToken ct)
    {
        var cargo = await _dbContextContext.Cargoes
                        .SingleOrDefaultAsync(c => c.Id == cmd.CargoId, ct)
                    ?? throw new KeyNotFoundException("Cargo not found");

        var crate = await _dbContextContext.Crates
                        .SingleOrDefaultAsync(c => c.Id == cmd.CrateId, ct)
                    ?? throw new KeyNotFoundException("Crate not found");

        crate.AssignToCargo(cargo.Id);
        cargo.AddCrate(crate.Id);

        await _dbContextContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}