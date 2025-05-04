using FluentValidation;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Application.Validators;

public class MoveCrateToMcCommandValidator : AbstractValidator<MoveCrateToMcCommand>
{
    public MoveCrateToMcCommandValidator()
    {
        RuleFor(x => x.CrateId).NotEmpty();
        RuleFor(x => x.McNumber)
            .Must(n => MobileContainerNumber.TryParse(n, out _))
            .WithMessage("MC number must be in format XX-YY (1–60 / 1–10).");
    }
}