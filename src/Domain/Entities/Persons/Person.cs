using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Persons;

public sealed class Person : AggregateRoot, IEntity
{
    public Person()
    {
    }

    public Person(
        string firstName,
        string? middleName,
        string lastName,
        string? maternalLastName,
        Rfc? rfc,
        Curp? curp,
        bool active
    )
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        MaternalLastName = maternalLastName;
        Rfc = rfc;
        Curp = curp;
        Active = active;
    }

    public PersonId Id { get; private set; } = new PersonId(Guid.NewGuid());

    public string FirstName { get; private set; } = string.Empty;

    public string? MiddleName { get; private set; }

    public string LastName { get; private set; } = string.Empty;

    public string? MaternalLastName { get; private set; }

    public string FullName => $"{FirstName} {MiddleName} {LastName} {MaternalLastName}";

    public string ShortName => $"{FirstName} {LastName}";

    public string InformalShortName => $"{FirstName} {MiddleName}";

    public Rfc? Rfc { get; private set; }

    public Curp? Curp { get; private set; }

    public bool Active { get; private set; }
}