using MediatR;

namespace SimpleWMS.Application.Commands;

public record AddInstanceToCargoCommand(Guid CargoId, string InstanceBarcode) : IRequest;