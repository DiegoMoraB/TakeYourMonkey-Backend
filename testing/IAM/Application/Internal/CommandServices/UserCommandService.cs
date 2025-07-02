using testing.IAM.Application.Internal.OutboundServices;
using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Model.Commands;
using testing.IAM.Domain.Repositories;
using testing.IAM.Domain.Services;
using IUnitOfWork = testing.Shared.Domain.Repositories.IUnitOfWork;

namespace testing.IAM.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository repository,
    IUnitOfWork unitOfWork, ITokenService tokenService,
    IHashingService hashingService) : IUserCommandService
{

    
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await repository.FindByUsernameAsync(command.user);
        
        if (user == null || !hashingService.VerifyPassword(command.password, user.PasswordHashed))
            throw new Exception("Invalid username or password");
        var token = tokenService.GenerateToken(user);
        
        return (user, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if(repository.ExistsByUsername(command.user))
            throw new Exception("Username already exists");
        
        var hashedPassword = hashingService.HashPassword(command.password);
        
        var user = new User(command.user, hashedPassword);

        try
        {
            await repository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}