using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class PlaceInstanceToMCCommandValidator : AbstractValidator<PlaceInstanceToMCCommand>
{
    public PlaceInstanceToMCCommandValidator()
    {
        RuleFor(x => x.InstanceBarcode).NotEmpty();
        RuleFor(x => x.McNumber).NotEmpty();
    }
}