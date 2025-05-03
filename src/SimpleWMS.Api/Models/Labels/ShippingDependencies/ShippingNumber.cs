namespace SimpleWMS.Api.Models.Labels.ShippingDependencies;

public class ShippingNumber
{
    public int UserId { get; set; }
    public short Number { get; set; }
    public byte ShippingPart { get; set; }
}