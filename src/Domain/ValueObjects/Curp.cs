using System.Text.RegularExpressions;

public partial record Curp
{
    private const string _PATTERN_REGEX = @"^[A-Z]{4}[0-9]{6}[HM][A-Z]{5}[0-9]{2}$";

    private Curp(string value) => Value = value;

    public string Value { get; init; }

    public static Curp? Create(string? value)
    {
        if (string.IsNullOrEmpty(value) || !CurpRegex().IsMatch(value))
        {
            return null;
        }

        return new Curp(value);
    }

    [GeneratedRegex(_PATTERN_REGEX)]
    private static partial Regex CurpRegex();
}