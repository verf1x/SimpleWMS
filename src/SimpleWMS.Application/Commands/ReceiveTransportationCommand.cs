using MediatR;

namespace SimpleWMS.Application.Commands;

public record ReceiveTransportationCommand(Guid TransportationId) : IRequest;