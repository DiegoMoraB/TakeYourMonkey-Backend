using Microsoft.EntityFrameworkCore;
using testing.Shared.Domain.Repositories;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;

namespace testing.Shared.Infrastructure.Persistence.EF.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    
    private readonly TakeYourMonkeyDbContext _context;

    public BaseRepository(TakeYourMonkeyDbContext context)
    {
        _context = context;
    }
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
}