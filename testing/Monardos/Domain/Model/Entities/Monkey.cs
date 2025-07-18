using testing.Monardos.Domain.Model.Aggregates;
using testing.Monardos.Domain.Model.Commands;
using testing.Shared.Domain.Model.Aggregates;

namespace testing.Monardos.Domain.Model.Entities;

public partial class Monkey
{
    public Monkey(CreateMonkeyCommand command)
    {
        Name = new UsernameValue(command.Name);
        TypeOfMonkeyId = command.TypeOfMonkeyId;
    }
    public int Id { get; private set; }
    public UsernameValue Name { get; private set; }
    public int TypeOfMonkeyId { get; private set; }
    public TypeOfMonkey? TypeOfMonkey { get; private set; }
    public Monkey()
    {
        Name = new UsernameValue();
        TypeOfMonkeyId = default(int);
    }
}