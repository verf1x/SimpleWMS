using SimpleWMS.Domain.Enums;
using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Domain.Entities;

public class Crate
{
    public Guid Id { get; set; }
    public CrateLocationCode LocationCode { get; private set; }
    public CrateStatus Status { get; private set; } = CrateStatus.Opened;
    public List<Guid> InstanceIds { get; } = new();

    private Crate() { }

    public Crate(string locationCode)
    {
        LocationCode = CrateLocationCode.Parse(locationCode);
        Status = CrateStatus.Opened;
    }

    public void AddInstance(Guid instanceId)
    {
        if (Status != CrateStatus.Opened)
            throw new InvalidOperationException("Cannot add to closed crate");
        InstanceIds.Add(instanceId);
    }

    public void Close()
    {
        if (Status != CrateStatus.Opened)
            throw new InvalidOperationException("Crate already closed");
        Status = CrateStatus.Collected;
    }
}