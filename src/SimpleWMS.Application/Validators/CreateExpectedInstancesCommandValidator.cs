using FluentValidation;
using SimpleWMS.Application.Commands;

namespace SimpleWMS.Application.Validators;

public class CreateExpectedInstancesCommandValidator
    : AbstractValidator<CreateExpectedInstancesCommand>
{
    public CreateExpectedInstancesCommandValidator()
    {
        RuleFor(x => x.Items).NotEmpty();

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ShippingNumber)
                .NotEmpty()
                .MaximumLength(32);
            item.RuleFor(i => i.SortType)
                .Must(s => s is "Sort" or "Nonsort")
                .WithMessage("SortType must be either 'Sort' or 'Nonsort'.");
        });
    }
}