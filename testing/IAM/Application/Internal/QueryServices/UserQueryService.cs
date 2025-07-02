using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Model.Queries;
using testing.IAM.Domain.Repositories;
using testing.IAM.Domain.Services;

namespace testing.IAM.Application.Internal.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository repository;

    public UserQueryService(IUserRepository userRepository)
    {
        repository = userRepository;
    }
    
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await repository.FindByIdAsync(query.id);
    }

    public Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<User?> Handle(GetUserByUsernameQuery query)
    {
        throw new NotImplementedException();
    }
}