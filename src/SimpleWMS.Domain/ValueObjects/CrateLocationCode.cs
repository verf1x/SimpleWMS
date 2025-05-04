using System.Text.RegularExpressions;

namespace SimpleWMS.Domain.ValueObjects;

public readonly struct CrateLocationCode
{
    public string Value { get; }
    private CrateLocationCode(string value) => Value = value;

    // Формат L-AA-BB_CC, L A-I, AA 1-6, BB 1-3, CC 1-3
    private static readonly Regex _regex = new("^[A-I]-(?:[1-6])-(?:[1-3])_(?:[1-3])$", RegexOptions.Compiled);

    public static CrateLocationCode Parse(string input)
    {
        if (!_regex.IsMatch(input))
            throw new ArgumentException($"Invalid crate location code: '{input}'", nameof(input));
        return new CrateLocationCode(input);
    }

    public static bool TryParse(string input, out CrateLocationCode result)
    {
        if (_regex.IsMatch(input))
        {
            result = new CrateLocationCode(input);
            return true;
        }
        result = default;
        return false;
    }

    public override string ToString() => Value;
}