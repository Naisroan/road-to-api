using Domain.ValueObjects;
using ErrorOr;

namespace Domain.DomainErrors;

public static partial class DomainErrors
{
    public static class Person
    {
        public static Error RfcBadFormat =>
            Error.Validation($"{nameof(Entities.Persons.Person)}.{nameof(Rfc)}", "El RFC no es válido");

        public static Error CurpBadFormat =>
            Error.Validation($"{nameof(Entities.Persons.Person)}.{nameof(Curp)}", "El CURP no es valido");
    }
}