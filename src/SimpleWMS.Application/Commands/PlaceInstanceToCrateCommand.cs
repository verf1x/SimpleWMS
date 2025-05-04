using MediatR;

namespace SimpleWMS.Application.Commands;

public record PlaceInstanceToCrateCommand(string InstanceBarcode, string CrateCode) : IRequest;