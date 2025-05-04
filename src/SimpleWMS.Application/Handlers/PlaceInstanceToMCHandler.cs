using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class PlaceInstanceToMCHandler : IRequestHandler<PlaceInstanceToMCCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public PlaceInstanceToMCHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(PlaceInstanceToMCCommand command, CancellationToken cancellationToken)
    {
        var mcNumber = MobileContainerNumber.Parse(command.McNumber);
        var mc = await _dbContext.MobileContainers.SingleOrDefaultAsync(m => m.Number == mcNumber, cancellationToken)
                 ?? throw new KeyNotFoundException("MC not found");
        var instance = await _dbContext.Instances.SingleOrDefaultAsync(i => i.ShippingNumber == command.InstanceBarcode, cancellationToken)
                       ?? throw new KeyNotFoundException("Instance not found");
        instance.PlaceToMC(mc.Id);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}