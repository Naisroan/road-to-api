using Domain.Entities.Persons;

namespace Application.Features.Persons.Commands;

/// <summary>
/// Command to create a person, returns a IRequest with a Person object
/// </summary>
public record CreatePersonCommand
(
    string? FirstName,
    string? MiddleName,
    string? LastName,
    string? MaternalLastName,
    string? Rfc,
    string? Curp
) : IRequest<ErrorOr<Person>>;