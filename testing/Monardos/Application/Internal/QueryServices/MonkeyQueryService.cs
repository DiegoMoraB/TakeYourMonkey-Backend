using testing.Monardos.Domain.Model.Entities;
using testing.Monardos.Domain.Model.Queries;
using testing.Monardos.Domain.Repositories;
using testing.Monardos.Domain.Services;

namespace testing.Monardos.Application.Internal.QueryServices;

public class MonkeyQueryService : IMonkeyQueryService
{
    IMonkeyRepository repository;
    public MonkeyQueryService(IMonkeyRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Monkey>> Handle(GetAllMonkeysQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Monkey?> Handle(GetMonkeyByIdQuery query)
    {
        return await repository.FindByIdAsync(query.id);
    }

    public async Task<Monkey?> Handle(GetMonkeyByNameQuery command)
    {
        return await repository.FindByNameAsync(command.name);
    }
}