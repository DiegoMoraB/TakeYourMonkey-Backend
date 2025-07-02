using testing.IAM.Domain.Model.Aggregates;
using testing.Shared.Domain.Repositories;

namespace testing.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}