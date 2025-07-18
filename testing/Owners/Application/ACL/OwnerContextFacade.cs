using testing.Owners.Domain.Services;
using testing.Owners.Interfaces.ACL;

namespace testing.Owners.Application.ACL;

public class OwnerContextFacade : IOwnerContextFacade
{
    private readonly IOwnerQueryServices queryServices;
    public bool existOwnerById(int ownerId)
    {
        throw new NotImplementedException();
    }
}