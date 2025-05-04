using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class PlaceInstanceToCrateHandler : IRequestHandler<PlaceInstanceToCrateCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public PlaceInstanceToCrateHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(PlaceInstanceToCrateCommand command, CancellationToken cancellationToken)
    {
        var crateCode = CrateLocationCode.Parse(command.CrateCode);
        var crate = await _dbContext.Crates.SingleOrDefaultAsync(c => c.LocationCode == crateCode, cancellationToken)
                    ?? throw new KeyNotFoundException("Crate not found");
        var instance = await _dbContext.Instances.SingleOrDefaultAsync(i => i.ShippingNumber == command.InstanceBarcode, cancellationToken)
                       ?? throw new KeyNotFoundException("Instance not found");
        instance.PlaceToCrate(crate.Id);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}