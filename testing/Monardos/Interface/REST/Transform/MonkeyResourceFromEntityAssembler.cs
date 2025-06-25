using testing.Monardos.Domain.Model.Entities;
using testing.Monardos.Interface.REST.Resources;

namespace testing.Monardos.Interface.REST.Transform;

public static class MonkeyResourceFromEntityAssembler
{
    public static MonkeyResource ToMonkeyResourceFromEntity(Monkey monkey)
    {
        return new MonkeyResource(
            monkey.Id,
            monkey.Name,
            monkey.TypeOfMonkeyId
        );
    }
}