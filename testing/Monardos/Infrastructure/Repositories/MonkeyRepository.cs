using Microsoft.EntityFrameworkCore;
using testing.Monardos.Domain.Model.Aggregates;
using testing.Monardos.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Repositories;

namespace testing.Monardos.Infrastructure.Repositories;

public class MonkeyRepository : BaseRepository<Monkey>,IMonkeyRepository
{
    private readonly TakeYourMonkeyDbContext context;

    public MonkeyRepository(TakeYourMonkeyDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Monkey?> FindByNameAsync(string name)
    {
        return await context.Set<Monkey>().Include(x => x.TypeOfMonkey)
            .FirstOrDefaultAsync(x => x.Name == name); 
    }
    
}