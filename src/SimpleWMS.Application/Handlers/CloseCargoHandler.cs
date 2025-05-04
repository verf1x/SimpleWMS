using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CloseCargoHandler : IRequestHandler<CloseCargoCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public CloseCargoHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(CloseCargoCommand cmd, CancellationToken ct)
    {
        var cargo = await _dbContext.Cargoes
                        .SingleOrDefaultAsync(c => c.Id == cmd.CargoId, ct)
                    ?? throw new KeyNotFoundException("Cargo not found");

        cargo.Close();
        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}