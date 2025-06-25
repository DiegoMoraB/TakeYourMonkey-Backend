using testing.Monardos.Domain.Model.Entities;
using testing.Monardos.Domain.Model.Commands;

namespace testing.Monardos.Domain.Services;

public interface IMonkeyCommandService
{
    Task<Monkey?> Handle(CreateMonkeyCommand command);
    Task Handle(DeleteMonkeyCommand command);
}