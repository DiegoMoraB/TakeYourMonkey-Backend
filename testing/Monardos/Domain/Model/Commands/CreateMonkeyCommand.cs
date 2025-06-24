using testing.Monardos.Domain.Model.ValueObjects;

namespace testing.Monardos.Domain.Model.Commands;

public record CreateMonkeyCommand(string Name,int TypeOfMonkeyId);