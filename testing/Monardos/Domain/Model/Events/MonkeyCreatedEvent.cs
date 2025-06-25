using testing.Shared.Domain.Model.Events;

namespace testing.Monardos.Domain.Model.Events;

public class MonkeyCreatedEvent(string name) : IEvent
{
    public string Name { get; set; } = name;
}