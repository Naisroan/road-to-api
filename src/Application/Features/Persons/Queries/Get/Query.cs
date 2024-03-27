using Domain.Entities.Persons;

namespace Application.Features.Persons.Queries;

public record GetPersonQuery(
    Guid Id
) : IRequest<ErrorOr<Person?>>;