using System.Text.RegularExpressions;

namespace SimpleWMS.Domain.ValueObjects;

public readonly struct MobileContainerNumber
{
    public string Value { get; }

    private MobileContainerNumber(string value) => Value = value;

    // Формат XX-YY, XX 1-60, YY 1-10
    private static readonly Regex _regex = new("^(?:[1-9]|[1-5][0-9]|60)-(?:[1-9]|10)$", RegexOptions.Compiled);

    public static MobileContainerNumber Parse(string input)
    {
        if (!_regex.IsMatch(input))
            throw new ArgumentException($"Invalid mobile container number: '{input}'", nameof(input));
        return new MobileContainerNumber(input);
    }

    public static bool TryParse(string input, out MobileContainerNumber result)
    {
        if (_regex.IsMatch(input))
        {
            result = new MobileContainerNumber(input);
            return true;
        }
        result = default;
        return false;
    }

    public override string ToString() => Value;
}