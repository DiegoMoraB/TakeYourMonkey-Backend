using testing.IAM.Domain.Model.Commands;
using testing.IAM.Interfaces.REST.Resources;

namespace testing.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new  SignUpCommand(resource.Username, resource.Password);
    }
}