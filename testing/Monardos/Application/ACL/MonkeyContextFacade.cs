using testing.Monardos.Domain.Model.Commands;
using testing.Monardos.Domain.Services;
using testing.Monardos.Interface.ACL;

namespace testing.Monardos.Application.ACL;

public class MonkeyContextFacade: IMonkeyContextFacade
{
    private readonly IMonkeyCommandService commandService;
    private readonly IMonkeyQueryService queryService;
    public MonkeyContextFacade(IMonkeyCommandService commandService, IMonkeyQueryService queryService)
    {
        this.commandService = commandService;
        this.queryService = queryService;
    }
    public async Task<int> CreateMonkey(string name, int tpeOfMonkeyId)
    {
        var createMonkeyCommand = new CreateMonkeyCommand(name, tpeOfMonkeyId);
        var monkey = await commandService.Handle(createMonkeyCommand);

        return monkey?.Id ?? 0;
    }
}