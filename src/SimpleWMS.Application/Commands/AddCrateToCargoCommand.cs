using MediatR;

namespace SimpleWMS.Application.Commands;

public record AddCrateToCargoCommand(Guid CargoId, Guid CrateId) : IRequest;