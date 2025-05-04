using Microsoft.VisualBasic.CompilerServices;
using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Domain.Entities;

public class Instance
{
    public Guid Id { get; set; }
    public required string ShippingNumber { get; set; } = string.Empty;
    public InstanceStatus Status { get; set; } = InstanceStatus.Expected;
    public Guid? AssignedCrateId { get; private set; }
    public Guid? AssignedMobileContainerId { get; set; }

    public Guid? CargoId { get; private set; }

    public SortType SortType { get; set; }

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
        if (Status is not (InstanceStatus.Expected or InstanceStatus.ReceivedReadyToPlace or InstanceStatus.Placed))
            throw new InvalidOperationException(
                $"Instance must be Expected or ReceivedReadyToPlace or Placed, but was {Status}");

        AssignedMobileContainerId = null;
        AssignedCrateId = null;

        CargoId = cargoId;
        Status = InstanceStatus.AddedToCargo;
    }

    public void MarkReceived()
    {
        if (Status != InstanceStatus.AddedToCargo)
            throw new InvalidOperationException(
                $"Cannot receive instance in status {Status}, expected {InstanceStatus.AddedToCargo}");

        CargoId = null;

        Status = InstanceStatus.ReceivedReadyToPlace;
    }
}

public enum SortType
{
    Sort,
    Nonsort
}