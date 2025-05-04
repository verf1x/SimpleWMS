using SimpleWMS.Domain.Enums;

namespace SimpleWMS.Domain.Entities;

public class Transportation
{
    public Guid Id { get; set; }
    public long TransportationNumber { get; set; }
    public required string RouteA { get; set; }
    public required string RouteB { get; set; }
    public required string VehicleData { get; set; }
    public DateOnly ShipmentDate { get; set; }
    public TransportationStatus Status { get; private set; } = TransportationStatus.Planned;
    public List<Guid> CargoIds { get; } = [];

    public void AddCargo(Guid cargoId)
    {
        if (Status != TransportationStatus.Planned)
            throw new InvalidOperationException("Cannot add cargo to non-planned transportation");
        CargoIds.Add(cargoId);
    }

    public void Start() => Status = TransportationStatus.InRoute;
    public void Complete() => Status = TransportationStatus.Completed;
}