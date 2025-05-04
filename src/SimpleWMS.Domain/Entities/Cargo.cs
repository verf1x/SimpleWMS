using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Domain.Entities;

public class Cargo
{
    public Guid Id { get; set; }
    public required string CargoName { get; set; }
    public required string CargoBarcode { get; set; }
    public CargoStatus Status { get; private set; } = CargoStatus.Forming;
    public Guid? TransportationId { get; private set; }
    public List<Guid> InstanceIds { get; } = [];

    public void AddInstance(Guid instanceId)
    {
        if (Status != CargoStatus.Forming)
            throw new InvalidOperationException("Cannot add instance to non-forming cargo");
        InstanceIds.Add(instanceId);
    }

    public void Close()
    {
        if (Status != CargoStatus.Forming)
            throw new InvalidOperationException("Only forming cargo can be closed");
        Status = CargoStatus.Collected;
    }

    public void Ship()
    {
        if (Status != CargoStatus.Collected)
            throw new InvalidOperationException("Only collected cargo can be shipped");
        Status = CargoStatus.Shipped;
    }
}