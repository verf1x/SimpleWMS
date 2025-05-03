namespace SimpleWMS.Api.Models.Labels.ShippingDependencies;

/// <summary>
/// Данные транспортного средства.
/// </summary>
public class VehicleData
{
    public string Make { get; set; } = string.Empty;
    
    public string CarNumber { get; set; } = string.Empty;
}