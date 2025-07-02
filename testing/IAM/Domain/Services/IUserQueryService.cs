using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Model.Queries;

namespace testing.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
}