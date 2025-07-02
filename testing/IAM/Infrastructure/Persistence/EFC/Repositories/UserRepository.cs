using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Repositories;

namespace testing.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(TakeYourMonkeyDbContext context) : BaseRepository<User>(context), IUserRepository
{
    
}