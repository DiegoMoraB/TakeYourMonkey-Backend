using Cortex.Mediator;
using testing.Monardos.Domain.Model.Entities;
using testing.Monardos.Domain.Model.Commands;
using testing.Monardos.Domain.Model.Events;
using testing.Monardos.Domain.Repositories;
using testing.Monardos.Domain.Services;
using testing.Shared.Domain.Repositories;

namespace testing.Monardos.Application.Internal.CommandServices;

public class MonkeyCommandService : IMonkeyCommandService
{
    IMonkeyRepository repository;
    IUnitOfWork unitOfWork;
    IMediator domainEventPublisher;
    public MonkeyCommandService(IMonkeyRepository repository,IUnitOfWork unitOfWork, IMediator domainEventPublisher)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.domainEventPublisher = domainEventPublisher;
    }
    
    public async Task<Monkey?> Handle(CreateMonkeyCommand command)
    {
       var monkey = new Monkey(command);
       
       if(monkey == null)
           throw new Exception("Monkey could not be created");
       try
       {
           await repository.AddAsync(monkey);
           await unitOfWork.CompleteAsync();
           await domainEventPublisher.PublishAsync(new MonkeyCreatedEvent(monkey.Name));
       }
       catch (Exception ex)
       {
           return null;
       }
       return monkey;
    }

    public async Task Handle(DeleteMonkeyCommand command)
    {
        var monkey = await repository.FindByIdAsync(command.id);
        
        if(monkey == null)
            throw new Exception("Monkey could not be found");

        try
        {
            repository.Remove(monkey);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Monkey could not be deleted", ex);
        }
    }
}