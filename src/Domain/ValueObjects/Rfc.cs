using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record Rfc
{
    private const string _PATTERN_REGEX = @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$";

    private Rfc(string value) => Value = value;

    public string Value { get; init; }

    public static Rfc? Create(string? value, bool hasHomoclave = false)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (!RfcRegex().IsMatch(value))
        {
            return null;
        }

        return new Rfc(value);
    }

    [GeneratedRegex(_PATTERN_REGEX)]
    private static partial Regex RfcRegex();
}