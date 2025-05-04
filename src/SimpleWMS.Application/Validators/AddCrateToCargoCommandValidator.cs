using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class AddCrateToCargoCommandValidator : AbstractValidator<AddCrateToCargoCommand>
{
    public AddCrateToCargoCommandValidator()
    {
        RuleFor(x => x.CargoId).NotEmpty();
        RuleFor(x => x.CrateId).NotEmpty();
    }
}