using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Interfaces.REST.Resources;

namespace testing.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToUserResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Name);
    }
}