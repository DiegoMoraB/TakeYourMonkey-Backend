using testing.Owners.Domain.Model.ValueObjects;

namespace testing.Owners.Domain.Model.Entities;

public partial class Owner
{
    public int Id { get; private set; }
    public UsernameValue Username { get; private set; }
    
}