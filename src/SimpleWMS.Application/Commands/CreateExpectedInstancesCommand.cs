using MediatR;

namespace SimpleWMS.Application.Commands;

public record CreateExpectedInstancesCommand(
    IList<CreateExpectedInstanceDto> Items) : IRequest<IList<Guid>>;

public record CreateExpectedInstanceDto(string ShippingNumber, string SortType);