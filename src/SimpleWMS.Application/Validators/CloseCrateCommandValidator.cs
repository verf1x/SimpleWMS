using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class CloseCrateCommandValidator : AbstractValidator<CloseCrateCommand>
{
    public CloseCrateCommandValidator() =>
        RuleFor(x => x.CrateId).NotEmpty();
}