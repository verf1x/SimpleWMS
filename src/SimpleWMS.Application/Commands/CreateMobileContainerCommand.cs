using MediatR;

namespace SimpleWMS.Application.Commands;

public record CreateMobileContainerCommand(string Number) : IRequest<Guid>;