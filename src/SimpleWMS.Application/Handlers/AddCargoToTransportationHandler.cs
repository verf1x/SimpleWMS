using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class AddCargoToTransportationHandler : IRequestHandler<AddCargoToTransportationCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    public AddCargoToTransportationHandler(SimpleWmsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(AddCargoToTransportationCommand cmd, CancellationToken ct)
    {
        var tr = await _dbContext.Transportations
                     .SingleOrDefaultAsync(t => t.Id == cmd.TransportationId, ct)
                 ?? throw new KeyNotFoundException("Transportation not found");

        var cargo = await _dbContext.Cargoes
                        .SingleOrDefaultAsync(c => c.Id == cmd.CargoId, ct)
                    ?? throw new KeyNotFoundException("Cargo not found");

        tr.AddCargo(cargo.Id);
        cargo.AssignToTransportation(tr.Id);
        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}