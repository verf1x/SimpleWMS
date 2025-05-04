using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Application.Dtos;

public class TransportationWithCargoDto
{
    public Guid Id { get; set; }
    public long Number { get; set; }
    public string RouteA { get; set; } = string.Empty;
    public string RouteB { get; set; } = string.Empty;
    public string VehicleData { get; set; } = string.Empty;
    public DateOnly ShipmentDate { get; set; }
    public TransportationStatus Status { get; set; }
    public List<CargoDto> Cargoes { get; set; } = new();
}

public class CargoDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CargoStatus Status { get; set; }
    public string Barcode { get; set; } = string.Empty;
}