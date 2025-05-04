using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Domain.Entities;

public class Instance
{
    public Guid Id { get; set; }
    public required string ShippingNumber { get; set; } = string.Empty;
    public InstanceStatus Status { get; private set; } = InstanceStatus.Expected;
    
    public void MarkReceived() => Status = InstanceStatus.ReceivedReadyToPlace;
}