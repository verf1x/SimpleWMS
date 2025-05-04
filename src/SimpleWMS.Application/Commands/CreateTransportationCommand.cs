using MediatR;

namespace SimpleWMS.Application.Commands;

public record CreateTransportationCommand(
    long TransportationNumber,
    string RouteA,
    string RouteB,
    string VehicleData,
    DateOnly ShipmentDate
) : IRequest<Guid>;