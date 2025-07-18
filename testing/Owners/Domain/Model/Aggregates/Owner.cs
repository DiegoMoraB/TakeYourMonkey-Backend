

using testing.Shared.Domain.Model.Aggregates;

namespace testing.Owners.Domain.Model.Aggregates;

public partial class Owner
{
    public int Id { get; private set; }
    public UsernameValue Username { get; private set; }
    public List<int> MonkeyIds { get; private set; }
}