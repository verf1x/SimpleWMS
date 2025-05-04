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

        if (instance.Status is not (InstanceStatus.Expected or InstanceStatus.ReceivedReadyToPlace
            or InstanceStatus.Placed))
            throw new InvalidOperationException(
                $"Instance must be Expected, ReadyToPlace or Placed, but was {instance.Status}");

        if (instance.AssignedMobileContainerId is not null)
        {
            instance.AssignedMobileContainerId = null;
        }

        if (instance.AssignedCrateId is not null)
        {
            var crate = await _dbContext.Crates.FindAsync(instance.AssignedCrateId, ct);
            crate?.InstanceIds.Remove(instance.Id);
            // instance.AssignedCrateId = null;
        }

        cargo.AddInstance(instance.Id);
        instance.AssignToCargo(cargo.Id);
        instance.Status = InstanceStatus.AddedToCargo;

        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}