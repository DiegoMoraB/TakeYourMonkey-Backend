using testing.Shared.Domain.Model.Aggregates;

namespace testing.Monardos.Interface.REST.Resources;

public record MonkeyResource(int id,UsernameValue name, int typeOfMonkeyId);