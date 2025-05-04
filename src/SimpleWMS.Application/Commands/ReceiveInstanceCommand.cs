using MediatR;

namespace SimpleWMS.Application.Commands;

public record ReceiveInstanceCommand(string InstanceBarcode, string TableQr) : IRequest;