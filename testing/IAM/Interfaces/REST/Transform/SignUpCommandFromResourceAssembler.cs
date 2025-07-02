using testing.IAM.Domain.Model.Commands;
using testing.IAM.Interfaces.REST.Resources;

namespace testing.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new  SignInCommand(resource.Username, resource.Password);
    }
}