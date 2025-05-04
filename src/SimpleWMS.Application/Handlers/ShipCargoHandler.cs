using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class ShipCargoHandler : IRequestHandler<ShipCargoCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public ShipCargoHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(ShipCargoCommand command, CancellationToken cancellationToken)
    {
        var cargo = await _dbContext.Cargoes.SingleOrDefaultAsync(c => c.Id == command.CargoId, cancellationToken)
                    ?? throw new KeyNotFoundException("Cargo not found");
        cargo.Ship();
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}