using ErrorOr;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Commands.Persons.Create;

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