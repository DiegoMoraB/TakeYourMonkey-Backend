using Cortex.Mediator.Notifications;
using testing.Shared.Domain.Model.Events;

namespace testing.Owners.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}