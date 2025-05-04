using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Application.Commands;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CloseCrateHandler : IRequestHandler<CloseCrateCommand>
{
    private readonly SimpleWmsDbContext _dbContext;
    
    public CloseCrateHandler(SimpleWmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CloseCrateCommand req, CancellationToken ct)
    {
        var crate = await _dbContext.Crates.SingleOrDefaultAsync(c => c.Id == req.CrateId, ct)
                    ?? throw new KeyNotFoundException($"Crate '{{req.CrateId}}' not found");
        crate.Close();
        await _dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}