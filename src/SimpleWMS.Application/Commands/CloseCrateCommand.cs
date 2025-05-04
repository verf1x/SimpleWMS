using MediatR;

namespace SimpleWMS.Application.Commands;

public record CloseCrateCommand(Guid CrateId) : IRequest;