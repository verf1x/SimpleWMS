using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class CloseCargoCommandValidator : AbstractValidator<CloseCargoCommand>
{
    public CloseCargoCommandValidator()
    {
        RuleFor(x => x.CargoId).NotEmpty();
    }
}