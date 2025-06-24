using testing.Monardos.Domain.Model.Aggregates;
using testing.Monardos.Domain.Model.Queries;

namespace testing.Monardos.Domain.Services;

public interface IMonkeyQueryService
{
    Task<IEnumerable<Monkey>> Handle(GetAllMonkeysQuery query);
    Task<Monkey?> Handle(GetMonkeyByIdQuery query);
    Task<Monkey?> Handle(GetMonkeyByNameQuery command);
}