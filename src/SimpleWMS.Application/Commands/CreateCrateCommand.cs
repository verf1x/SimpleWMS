using MediatR;

namespace SimpleWMS.Application.Commands;

public record CreateCrateCommand(string LocationCode) : IRequest<Guid>;