using FluentValidation;
using SimpleWMS.Application.Commands;
using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Application.Validators;

public class CreateMobileContainerCommandValidator
    : AbstractValidator<CreateMobileContainerCommand>
{
    public CreateMobileContainerCommandValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .Must(number => MobileContainerNumber.TryParse(number, out _))
            .WithMessage("Invalid MC number format, expected XX-YY");
    }
}