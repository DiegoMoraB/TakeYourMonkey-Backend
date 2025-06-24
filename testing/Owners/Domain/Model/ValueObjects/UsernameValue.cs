using System.Text.RegularExpressions;

namespace testing.Owners.Domain.Model.ValueObjects;

public record UsernameValue(string username)
{
    private static readonly Regex _pattern = new(@"^[A-Za-z0-9_]{3,16}$");
    public static UsernameValue Create(string username)
    {
        
        if (!_pattern.IsMatch(username))
        {
            throw new Exception($"Username '{username}' is not valid.");
        }
        return new UsernameValue(username);
    }
}