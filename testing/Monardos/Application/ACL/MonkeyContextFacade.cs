using testing.Monardos.Application.Internal.CommandServices;
using testing.Monardos.Application.Internal.QueryServices;
using testing.Monardos.Domain.Model.Commands;
using testing.Monardos.Interface.ACL;

namespace testing.Monardos.Application.ACL;

public class MonkeyContextFacade (MonkeyCommandService commandService,
    MonkeyQueryService queryService) : IMonkeyContextFacade
{
    public async Task<int> CreateMonkey(string name, int tpeOfMonkeyId)
    {
        var createMonkeyCommand = new CreateMonkeyCommand(name, tpeOfMonkeyId);
        var monkey = await commandService.Handle(createMonkeyCommand);

        return monkey?.Id ?? 0;
    }
}