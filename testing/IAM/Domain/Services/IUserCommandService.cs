using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Model.Commands;

namespace testing.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    Task Handle(SignUpCommand command);
}