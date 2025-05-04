using MediatR;

namespace SimpleWMS.Application.Commands;

public record PlaceInstanceToMCCommand(string InstanceBarcode, string McNumber) : IRequest;