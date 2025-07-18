using System.Text.RegularExpressions;

namespace testing.Shared.Domain.Model.Aggregates;

public record UsernameValue
{
    public string Value { get; init; }
    private static readonly Regex _pattern = new(@"^[A-Za-z0-9_]{3,16}$");
    public UsernameValue(string username)
    {
        if (!_pattern.IsMatch(username))
        {
            throw new Exception($"Username '{username}' is not valid.");
        }
        Value = username;
    }

    public UsernameValue()
    {
        Value = "empty";
    }
}