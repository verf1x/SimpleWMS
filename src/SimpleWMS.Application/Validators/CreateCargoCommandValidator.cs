using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class CreateCargoCommandValidator : AbstractValidator<CreateCargoCommand>
{
    public CreateCargoCommandValidator()
    {
        RuleFor(x => x.CargoName).NotEmpty();
        RuleFor(x => x.CargoBarcode).NotEmpty();
    }
}