using testing.Monardos.Interface.ACL;

namespace testing.Owners.Application.Internal.OutboundServices.ACL;

public class ExternalMonkeyServices(IMonkeyContextFacade monkeyContextFacade)
{
    public async Task<int> CreateMonkey(string name, int tpeOfMonkeyId)
    {
        return await monkeyContextFacade.CreateMonkey(name, tpeOfMonkeyId);
    }
}