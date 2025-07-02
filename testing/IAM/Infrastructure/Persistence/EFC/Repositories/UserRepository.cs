using Microsoft.EntityFrameworkCore;
using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Repositories;

namespace testing.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(TakeYourMonkeyDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await context.Set<User>().FirstOrDefaultAsync(u => u.Name.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return context.Set<User>().Any(u => u.Name.Equals(username));
    }
}