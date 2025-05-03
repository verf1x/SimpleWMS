using SimpleWMS.Api.Models.Labels.ShippingDependencies;

namespace SimpleWMS.Api.Models.Labels;

#nullable disable

/// <summary>
/// Этикетка отправления
/// </summary>
public class PostingLabel
{
    public ShippingType ShippingType { get; set; }
    public ShippingNumber ShippingNumber { get; set; }
    public string Warehouse { get; set; } = string.Empty;
    public string TargetDestination { get; set; } = string.Empty;
    public Barcode PostingBarcode { get; set; }
}