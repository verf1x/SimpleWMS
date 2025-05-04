using MediatR;
using SimpleWMS.Application.Dtos;

namespace SimpleWMS.Application.Queries;

public record GetTransportationWithCargoQuery(Guid TransportationId) : IRequest<TransportationWithCargoDto>;