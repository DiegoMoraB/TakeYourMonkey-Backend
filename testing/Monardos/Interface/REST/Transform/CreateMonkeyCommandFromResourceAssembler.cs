using testing.Monardos.Domain.Model.Commands;
using testing.Monardos.Interface.REST.Resources;

namespace testing.Monardos.Interface.REST.Transform;

public static class CreateMonkeyCommandFromResourceAssembler
{
    public static CreateMonkeyCommand ToCreateMonkeyCommand(this CreateMonkeyResource resource)
    {
        return new CreateMonkeyCommand(
        resource.name,
        resource.typeOfMonkeyId
            );
    }
}