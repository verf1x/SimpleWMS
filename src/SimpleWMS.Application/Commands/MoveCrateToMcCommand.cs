using MediatR;

namespace SimpleWMS.Application.Commands;

public record MoveCrateToMcCommand(Guid CrateId, string McNumber) : IRequest;