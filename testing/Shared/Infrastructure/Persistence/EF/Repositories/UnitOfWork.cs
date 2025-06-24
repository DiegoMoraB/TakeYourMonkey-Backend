using testing.Shared.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;

namespace testing.Shared.Infrastructure.Persistence.EF.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TakeYourMonkeyDbContext context;

    public UnitOfWork(TakeYourMonkeyDbContext context)
    {
        this.context = context;
    }
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}