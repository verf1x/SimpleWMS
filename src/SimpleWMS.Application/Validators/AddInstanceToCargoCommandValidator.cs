using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class AddInstanceToCargoCommandValidator : AbstractValidator<AddInstanceToCargoCommand>
{
    public AddInstanceToCargoCommandValidator()
    {
        RuleFor(x => x.CargoId).NotEmpty();
        RuleFor(x => x.InstanceBarcode).NotEmpty();
    }
}