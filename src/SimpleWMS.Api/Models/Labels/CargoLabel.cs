namespace SimpleWMS.Api.Models.Labels;

#nullable disable

/// <summary>
/// Этикетка груза
/// </summary>
public class CargoLabel
{
    public string CargoName { get; set; } = string.Empty;
    public string TargetDestination { get; set; } = string.Empty;
    public Barcode CargoBarcode { get; set; }
}