namespace SimpleWMS.Domain.Entities;

public class Instance
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string PostingBarcode { get; private set; } = string.Empty;
    
    public InstanceStatus Status { get; private set; } = InstanceStatus.Expected;
    
    private Instance() { }

    public static Instance Create(string postingBarcode)
    {
        return new()
        {
            PostingBarcode = postingBarcode
        };
    } 
}

public enum InstanceStatus
{
    Expected,
    Picked
}