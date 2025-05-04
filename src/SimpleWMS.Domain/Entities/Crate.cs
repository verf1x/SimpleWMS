using SimpleWMS.Domain.Enums;
using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Domain.Entities;

public class Crate
{
    public Guid Id { get; set; }
    public CrateLocationCode LocationCode { get; private set; }
    public CrateStatus Status { get; set; } = CrateStatus.Opened;
    public Guid? MobileContainerId { get; private set; }
    
    public Guid? CargoId { get; private set; }

    public Crate() { }

    public Crate(string locationCode)
    {
        LocationCode = CrateLocationCode.Parse(locationCode);
        Status = CrateStatus.Opened;
    }

    public void AssignLocation(string code)
        => LocationCode = CrateLocationCode.Parse(code);
    
    public void Close()
    {
        if (Status != CrateStatus.Opened)
            throw new InvalidOperationException("Crate already closed");
        Status = CrateStatus.Collected;
    }
    
    public void MoveToMobileContainer(Guid mcId)
    {
        if (Status != CrateStatus.Collected)
            throw new InvalidOperationException("Crate must be collected before move.");
        MobileContainerId = mcId;
    }
    
    public void AssignToCargo(Guid cargoId)
    {
        if (Status != CrateStatus.Collected)
            throw new InvalidOperationException("Crate must be collected before assigning to cargo.");

        if (CargoId is not null)
            throw new InvalidOperationException("Crate is already assigned to a cargo.");
        
        MobileContainerId = null;
        CargoId = cargoId;
    }
}