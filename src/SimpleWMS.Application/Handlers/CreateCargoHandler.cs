using MediatR;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CreateCargoHandler : IRequestHandler<CreateCargoCommand, Guid>
{
    private readonly SimpleWmsDbContext _dbContext;
    
    public CreateCargoHandler(SimpleWmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateCargoCommand req, CancellationToken ct)
    {
        Cargo cargo = new()
        {
            Id = Guid.NewGuid(), 
            CargoName = req.CargoName, 
            CargoBarcode = req.CargoBarcode
        };
        
        _dbContext.Cargoes.Add(cargo);
        
        await _dbContext.SaveChangesAsync(ct);
        return cargo.Id;
    }
}