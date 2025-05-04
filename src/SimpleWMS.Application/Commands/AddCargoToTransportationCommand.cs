using MediatR;

namespace SimpleWMS.Application.Commands;

public record AddCargoToTransportationCommand(Guid TransportationId, Guid CargoId) : IRequest;