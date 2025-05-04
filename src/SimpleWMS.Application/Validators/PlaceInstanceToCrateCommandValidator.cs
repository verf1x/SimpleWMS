using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class PlaceInstanceToCrateCommandValidator : AbstractValidator<PlaceInstanceToCrateCommand>
{
    public PlaceInstanceToCrateCommandValidator()
    {
        RuleFor(x => x.InstanceBarcode).NotEmpty();
        RuleFor(x => x.CrateCode).NotEmpty();
    }
}