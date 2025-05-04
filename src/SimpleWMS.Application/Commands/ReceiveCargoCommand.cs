using MediatR;

namespace SimpleWMS.Application.Commands;

public record ReceiveCargoCommand(string CargoBarcode) : IRequest;