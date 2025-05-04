using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class ReceiveInstanceHandler : IRequestHandler<ReceiveInstanceCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public ReceiveInstanceHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(ReceiveInstanceCommand command, CancellationToken cancellationToken)
    {
        var instance = await _dbContext.Instances.SingleOrDefaultAsync(i => i.ShippingNumber == command.InstanceBarcode, cancellationToken)
                       ?? throw new KeyNotFoundException("Instance not found");
        instance.MarkReceived();
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}