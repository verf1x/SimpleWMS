using MediatR;

namespace SimpleWMS.Application.Commands;

public record CreateCargoCommand(string CargoName, string CargoBarcode) : IRequest<Guid>;