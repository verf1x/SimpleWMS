namespace SimpleWMS.Api.Models.Labels.ShippingDependencies;

/// <summary>
/// Номер отправления в формате XXXXXXXX-XXXX-XX.
/// </summary>
public class ShippingNumber
{
    public int UserId { get; set; }
    
    public short Number { get; set; }
    
    public byte ShippingPart { get; set; }

    public override string ToString()
    {
        return $"{UserId}-{Number}-{ShippingPart}";
    }
}