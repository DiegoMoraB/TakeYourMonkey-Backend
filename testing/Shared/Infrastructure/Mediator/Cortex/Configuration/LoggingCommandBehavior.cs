using Cortex.Mediator.Commands;

namespace testing.Shared.Infrastructure.Mediator.Cortex.Configuration;

public class LoggingCommandBehavior<TCommand> :
    ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(TCommand command, CommandHandlerDelegate next, CancellationToken cancellationToken)
    {
        await next();
    }
}