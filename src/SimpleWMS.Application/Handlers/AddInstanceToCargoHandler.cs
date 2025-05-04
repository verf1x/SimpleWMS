using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Enums;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class AddInstanceToCargoHandler : IRequestHandler<AddInstanceToCargoCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public AddInstanceToCargoHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(AddInstanceToCargoCommand cmd, CancellationToken ct)
    {
        var cargo = await _dbContext.Cargoes
                        .SingleOrDefaultAsync(c => c.Id == cmd.CargoId, ct)
                    ?? throw new KeyNotFoundException($"Cargo {cmd.CargoId} not found");

        var instance = await _dbContext.Instances
                           .SingleOrDefaultAsync(i => i.ShippingNumber == cmd.InstanceBarcode, ct)
                       ?? throw new KeyNotFoundException($"Instance {cmd.InstanceBarcode} not found");

        if (instance.Status != InstanceStatus.Expected)
            throw new InvalidOperationException("Only Expected instances can be added to a forming cargo.");

        cargo.AddInstance(instance.Id);
        instance.AssignToCargo(cargo.Id);
        instance.Status = InstanceStatus.AddedToCargo;

        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}