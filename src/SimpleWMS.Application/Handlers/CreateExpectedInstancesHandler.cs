using MediatR;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Domain.Enums;
using SimpleWMS.Persistence;

namespace SimpleWMS.Application.Handlers;

public class CreateExpectedInstancesHandler
    : IRequestHandler<CreateExpectedInstancesCommand, IList<Guid>>
{
    private readonly SimpleWmsDbContext _db;
    public CreateExpectedInstancesHandler(SimpleWmsDbContext db) => _db = db;

    public async Task<IList<Guid>> Handle(CreateExpectedInstancesCommand cmd, CancellationToken ct)
    {
        var ids = new List<Guid>();

        foreach (var dto in cmd.Items)
        {
            var entity = new Instance
            {
                Id             = Guid.NewGuid(),
                ShippingNumber = dto.ShippingNumber,
                SortType       = dto.SortType == "Sort" ? SortType.Sort : SortType.Nonsort,
                Status         = InstanceStatus.Expected
            };
            ids.Add(entity.Id);
            _db.Instances.Add(entity);
        }

        await _db.SaveChangesAsync(ct);
        return ids;
    }
}