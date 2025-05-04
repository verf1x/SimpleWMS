using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class ReceiveCargoHandler : IRequestHandler<ReceiveCargoCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    
    public ReceiveCargoHandler(SimpleWmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(ReceiveCargoCommand command, CancellationToken cancellationToken)
    {
        var cargo = await _dbContext.Cargoes
                        .SingleOrDefaultAsync(c => c.CargoBarcode == command.CargoBarcode, cancellationToken)
                    ?? throw new KeyNotFoundException($"Cargo with barcode {command.CargoBarcode} not found");

        cargo.MarkReceived();
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}