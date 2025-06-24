using testing.Monardos.Domain.Model.Commands;
using testing.Monardos.Domain.Model.ValueObjects;

namespace testing.Monardos.Domain.Model.Aggregates;

public partial class Monkey
{
    public Monkey(CreateMonkeyCommand command)
    {
        Name = command.Name;
        TypeOfMonkeyId = command.TypeOfMonkeyId;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int TypeOfMonkeyId { get; private set; }
    public TypeOfMonkey? TypeOfMonkey { get; private set; }

}