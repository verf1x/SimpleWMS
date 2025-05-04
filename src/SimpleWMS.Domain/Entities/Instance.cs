using Microsoft.VisualBasic.CompilerServices;
using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Domain.Entities;

public class Instance
{
    public Guid Id { get; set; }
    public required string ShippingNumber { get; set; } = string.Empty;
    public InstanceStatus Status { get; set; } = InstanceStatus.Expected;
    public Guid? AssignedCrateId { get; private set; }
    public Guid? AssignedMobileContainerId { get; private set; }
    
    public Guid? CargoId { get; private set; }
    
    public SortType SortType { get; set; }
    
    public void MarkReceived() => Status = InstanceStatus.ReceivedReadyToPlace;
    
    public void PlaceToMC(Guid mcId)
    {
        if (Status != InstanceStatus.ReceivedReadyToPlace)
            throw new InvalidOperationException("Instance must be ReadyToPlace");
        AssignedMobileContainerId = mcId;
        Status = InstanceStatus.Placed;
    }
    public void PlaceToCrate(Guid crateId)
    {
        if (Status != InstanceStatus.ReceivedReadyToPlace)
            throw new InvalidOperationException("Instance must be ReadyToPlace");
        AssignedCrateId = crateId;
        Status = InstanceStatus.Placed;
    }
    
    public void AssignToCargo(Guid cargoId)
    {
        if (Status is not (InstanceStatus.Expected or InstanceStatus.ReceivedReadyToPlace))
            throw new InvalidOperationException(
                $"Instance must be Expected or ReceivedReadyToPlace, but was {Status}");

        CargoId = cargoId;
        Status  = InstanceStatus.AddedToCargo;
    }
}

public enum SortType
{
    Sort,
    Nonsort
}