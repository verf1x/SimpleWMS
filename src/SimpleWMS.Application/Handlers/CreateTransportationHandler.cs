using MediatR;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CreateTransportationHandler : IRequestHandler<CreateTransportationCommand, Guid>
{
    private readonly SimpleWmsDbContext _dbContext;
    public CreateTransportationHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateTransportationCommand cmd, CancellationToken ct)
    {
        var entity = new Transportation
        {
            Id = Guid.NewGuid(),
            TransportationNumber = cmd.TransportationNumber,
            RouteA = cmd.RouteA,
            RouteB = cmd.RouteB,
            VehicleData = cmd.VehicleData,
            ShipmentDate = cmd.ShipmentDate
        };
        _dbContext.Transportations.Add(entity);
        await _dbContext.SaveChangesAsync(ct);
        return entity.Id;
    }
}