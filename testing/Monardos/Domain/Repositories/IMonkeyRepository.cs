using testing.Monardos.Domain.Model.Entities;
using testing.Shared.Domain.Repositories;

namespace testing.Monardos.Domain.Repositories;

public interface IMonkeyRepository : IBaseRepository<Monkey>
{
    Task<Monkey?> FindByNameAsync(string name);
}