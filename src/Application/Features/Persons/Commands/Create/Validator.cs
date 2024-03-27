using FluentValidation;

namespace Application.Features.Persons.Commands;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Primer nombre");

        RuleFor(r => r.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Segundo nombre");
    }
}