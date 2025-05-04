using FluentValidation;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Application.Validators;

public class CreateCrateCommandValidator : AbstractValidator<CreateCrateCommand>
{
    public CreateCrateCommandValidator()
    {
        RuleFor(x => x.LocationCode)
            .NotEmpty()
            .Must(code => CrateLocationCode.TryParse(code, out _))
            .WithMessage("Invalid crate code format, expected L-AA-BB_CC (A–I / 1–6 / 1–3 / 1–3)");
    }
}