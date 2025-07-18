using testing.Owners.Domain.Model.Aggregates;
using testing.Shared.Domain.Repositories;

namespace testing.Owners.Domain.Repositories;

public interface IOwnerRepository : IBaseRepository<Owner>
{
    
}