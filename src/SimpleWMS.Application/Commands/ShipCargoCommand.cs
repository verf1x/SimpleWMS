using MediatR;

namespace SimpleWMS.Application.Commands;

public record ShipCargoCommand(Guid CargoId) : IRequest;