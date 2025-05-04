using MediatR;

namespace SimpleWMS.Application.Commands;

public record CloseCargoCommand(Guid CargoId) : IRequest;