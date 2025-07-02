using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Interfaces.REST.Resources;

namespace testing.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Name, token);
    }
}