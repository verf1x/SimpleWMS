using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class ReceiveTransportationHandler : IRequestHandler<ReceiveTransportationCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public ReceiveTransportationHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(ReceiveTransportationCommand cmd, CancellationToken ct)
    {
        var transportation = await _dbContext.Transportations
                     .SingleOrDefaultAsync(t => t.Id == cmd.TransportationId, ct)
                 ?? throw new KeyNotFoundException("Transportation not found");
        transportation.Start();
        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}