using SimpleWMS.Api.Models.Codes;
using SimpleWMS.Api.Models.Labels.ShippingDependencies;

namespace SimpleWMS.Api.Models.Labels;

#nullable disable

/// <summary>
/// Этикетка перевозки груза
/// </summary>
public class TransportationLabel
{
    public TransportationRoute Route { get; set; }
    
    public long TransportationNumber { get; set; }
    
    public int CargoPlacesCount { get; set; }
    
    public VehicleData VehicleData { get; set; }
    
    public DateOnly ShipmentDate { get; set; }
    
    public Barcode ShipmentBarcode { get; set; }
}
