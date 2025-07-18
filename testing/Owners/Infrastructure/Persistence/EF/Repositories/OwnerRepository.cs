using testing.Owners.Domain.Model.Aggregates;
using testing.Owners.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Repositories;

namespace testing.Owners.Infrastructure.Persistence.EF.Repositories;

public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(TakeYourMonkeyDbContext context) : base(context)
    {
    }
}