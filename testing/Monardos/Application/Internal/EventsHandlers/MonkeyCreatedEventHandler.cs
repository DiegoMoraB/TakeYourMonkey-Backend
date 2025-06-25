using testing.Monardos.Domain.Model.Events;
using testing.Shared.Application.Internal.EventHandlers;

namespace testing.Monardos.Application.Internal.EventsHandlers;

public class MonkeyCreatedEventHandler : IEventHandler<MonkeyCreatedEvent>
{
    public Task Handle(MonkeyCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    private static Task On(MonkeyCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Monkey Event : {0}",domainEvent.Name);
        return Task.CompletedTask;
    }
}