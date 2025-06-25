using Cortex.Mediator.Notifications;
using testing.Shared.Domain.Model.Events;

namespace testing.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEntity> : INotificationHandler<TEntity> where TEntity : IEvent
{
    
}