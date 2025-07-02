using System.Text.Json.Serialization;

namespace testing.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHashed)
{
    public User() : this(string.Empty, string.Empty) { }
    
    public int Id {get;set;}
    public string Name {get;set;}
    [JsonIgnore] public string PasswordHashed {get;set;}

    public User UpdateName(string name)
    {
        Name = name;
        return this;
    }
}