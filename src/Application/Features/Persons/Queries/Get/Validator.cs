using Application.Features.Persons.Queries;
using FluentValidation;

public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}